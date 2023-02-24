using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour
{
    [Tooltip("Ship speed")]
    [SerializeField] private float Velocity = 4;

    [Tooltip("Damage explosion")]
    [SerializeField] private int Damage = 25;

    [Tooltip("Ship turning speed")]
    [SerializeField][Range(0, 1)] private float VelocityAngular = 0.1f;

    [Tooltip("Explosion effect")]
    [SerializeField] private GameObject Explosion;

    // Privates
    private Rigidbody2D Rigid;
    private Transform Target;

    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        Target = GameObject.FindWithTag("Player").transform.GetChild(0);
    }

    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        Rigid.MovePosition(Vector2.MoveTowards(transform.position, Target.position, Velocity * Time.deltaTime));
        transform.up = Vector3.Lerp(transform.up, Target.position - transform.position, Time.deltaTime * VelocityAngular);
        transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject Obj = Instantiate(Explosion, transform.position, transform.rotation);
            Obj.transform.localScale = Vector3.one * 2;

            if (collision.transform.TryGetComponent<LifeSystem>(out var Life))
                Life.Hit(Damage);

            Destroy(transform.parent.gameObject);
        }
    }
}
