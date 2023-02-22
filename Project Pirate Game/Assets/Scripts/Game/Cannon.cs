using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject CannolBall;
    [SerializeField] int ForceShot = 10;
    [SerializeField] float TimeDestroyBall = 3;
    [SerializeField] float FireRate = 5;

    //privates
    private bool CanShoot = true;
    private Transform LocalFire;

    private void Start()
    {
        LocalFire = transform.GetChild(0);
    }

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
        GameObject Ball = Instantiate(CannolBall, LocalFire.position, LocalFire.rotation);
        
        Ball.GetComponent<Rigidbody2D>().AddForce(transform.right * ForceShot, ForceMode2D.Impulse);
        Destroy(Ball, TimeDestroyBall);

        yield return new WaitForSeconds(FireRate);
        CanShoot = true;
    }
}
