using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    [SerializeField] float DistanceAttack = 4;
    [SerializeField] float DistanceBestAttack = 2;
    [SerializeField] float Velocity = 3;
    [SerializeField][Range(1, 100)] float VelocityAngular = 100;
    [SerializeField] Transform Player;
    [SerializeField] Cannon[] Cannons;

    //Privates
    private Rigidbody2D Rigid;
    
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float Distance = Vector3.Distance(transform.position, Player.position);

        if (Distance > DistanceAttack)
        {
            EnemyMove();
        }

        else if (Distance > DistanceBestAttack)
        {
            EnemyMove();

            if (Cannons[0].CanShoot && !Player.GetComponent<LifeSystem>().Destroyed)
                StartCoroutine(Cannons[0].Shoot());
        }
        else
        {
            EnemyMove(true);
            foreach (Cannon c in Cannons)
            {
                if (c.CanShoot && !Player.GetComponent<LifeSystem>().Destroyed)
                    StartCoroutine(c.Shoot());
            }
        }
    }
    private void EnemyMove(bool BestAttack= false)
    {
        if (BestAttack)
            transform.right = Vector3.Lerp(transform.right, Player.position - transform.position, Time.deltaTime * VelocityAngular / 10);
        else
        {
            Rigid.MovePosition(Vector2.MoveTowards(transform.position, Player.position, Velocity * Time.deltaTime));
            transform.up = Vector3.Lerp(transform.up, Player.position - transform.position, Time.deltaTime * VelocityAngular / 10);
        }
    }
}
