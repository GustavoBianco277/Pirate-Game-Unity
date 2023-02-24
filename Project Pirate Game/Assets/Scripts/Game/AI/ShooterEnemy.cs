using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [Tooltip("Single attack distance")]
    [SerializeField] private float DistanceAttack = 4;

    [Tooltip("Multiple attack distance")]
    [SerializeField] private float DistanceBestAttack = 3;

    [Tooltip("Ship speed")]
    [SerializeField] private float Velocity = 3;

    [Tooltip("Ship turning speed")]
    [SerializeField][Range(0, 1)] private float VelocityAngular = 0.1f;

    [Tooltip("Cannons list")]
    [SerializeField] private Cannon[] Cannons;

    //Privates
    private Rigidbody2D Rigid;
    private Transform Target;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Target = GameObject.FindWithTag("Player").transform.GetChild(0);
    }

    void Update()
    {
        float Distance = Vector3.Distance(transform.position, Target.position);

        if (Distance > DistanceAttack)
        {
            EnemyMove();
        }

        else if (Distance > DistanceBestAttack)
        {
            EnemyMove();

            if (Cannons[0].CanShoot && !Target.parent.GetComponent<LifeSystem>().Destroyed)
                StartCoroutine(Cannons[0].Shoot());
        }
        else
        {
            EnemyMove(true);
            foreach (Cannon c in Cannons)
            {
                if (c.CanShoot && !Target.parent.GetComponent<LifeSystem>().Destroyed)
                    StartCoroutine(c.Shoot());
            }
        }
    }
    private void EnemyMove(bool BestAttack= false)
    {
        if (BestAttack)
            transform.right = Vector3.Lerp(transform.right, Target.position - transform.position, Time.deltaTime * VelocityAngular);

        else
        {
            Rigid.MovePosition(Vector2.MoveTowards(transform.position, Target.position, Velocity * Time.deltaTime));
            /*Vector2 direction = Target.position - transform.position + -transform.up;
            float angle = Vector2.Angle(Rigid.transform.position, direction);
            Rigid.MoveRotation(Mathf.LerpAngle(Rigid.rotation, angle, VelocityAngular * Time.deltaTime));*/
            transform.up = Vector3.Lerp(transform.up, Target.position - transform.position, Time.deltaTime * VelocityAngular);
        }
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }
}
