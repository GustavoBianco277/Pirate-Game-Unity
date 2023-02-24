using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Tooltip("Projectil of cannon")]
    [SerializeField] private GameObject CannolBall;

    [Tooltip("Cannon fire force")]
    [SerializeField] private int ForceShot = 10;

    [Tooltip("Time to destroy projectil")]
    [SerializeField] private float TimeDestroyBall = 3;

    [Tooltip("Seconds per cannon shot")]
    [SerializeField] private float FireRate = 5;

    [Tooltip("Cannon ready to fire")]
    public bool CanShoot = true;

    //privates
    private Transform LocalFire;  //Local instantiate projectil
    private LifeSystem Life;
    private DurationMatch Match;
    private bool Active = true;

    private void Start()
    {
        LocalFire = transform.GetChild(0);
        Life = transform.parent.GetComponent<LifeSystem>();
        Match = FindObjectOfType<DurationMatch>();
        Active = transform.parent.GetComponent<ShipMove>() != null ? true : false;
    }

    void Update()
    {
        if (Active)
        {
            if (Input.GetMouseButtonDown(0) && CanShoot && !Life.Destroyed && !Match.EndOfGame)
            {
                StartCoroutine(Shoot());
            }
        }
    }
    public IEnumerator Shoot()
    {
        CanShoot = false;
        GameObject Ball = Instantiate(CannolBall, LocalFire.position, LocalFire.rotation);
        
        Ball.GetComponent<Rigidbody2D>().AddForce(transform.right * ForceShot, ForceMode2D.Impulse);
        Ball.GetComponent<Ball>().Owner = transform.parent;
        Destroy(Ball, TimeDestroyBall);

        yield return new WaitForSeconds(FireRate);
        CanShoot = true;
    }
}
