using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private bool CanShoot = true;
    [SerializeField] GameObject CannolBall;
    [SerializeField] GameObject Explosion;
    [SerializeField] int ForceShot = 10;
    [SerializeField] float TimeDestroyBall = 3;
    [SerializeField] float FireRate = 5;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanShoot)
        {
            StartCoroutine(Shoot());
        }
    }
    public IEnumerator Shoot()
    {
        CanShoot = false;
        Destroy(Instantiate(Explosion, transform.GetChild(0)), 0.2f);
        GameObject Ball = Instantiate(CannolBall, transform.GetChild(0));
        
        Ball.GetComponent<Rigidbody2D>().AddForce(transform.right * ForceShot, ForceMode2D.Impulse);
        Destroy(Ball, TimeDestroyBall);
        Ball.transform.SetParent(transform.root.parent);

        yield return new WaitForSeconds(FireRate);
        CanShoot = true;
    }
}
