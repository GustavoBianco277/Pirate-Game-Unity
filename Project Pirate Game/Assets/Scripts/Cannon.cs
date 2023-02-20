using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private Transform LocalBalls;
    [SerializeField] GameObject CannolBall;
    [SerializeField] int ForceShot = 10;
    [SerializeField] float TimeToDestroy = 10;

    void Start()
    {
        LocalBalls = GameObject.Find("Balls").transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }
    public void Shot()
    {
        GameObject Ball = Instantiate(CannolBall, transform.GetChild(0));
        Ball.GetComponent<Rigidbody2D>().AddForce(transform.right * ForceShot, ForceMode2D.Impulse);
        Destroy(Ball, TimeToDestroy);
        Ball.transform.SetParent(LocalBalls);
    }
}
