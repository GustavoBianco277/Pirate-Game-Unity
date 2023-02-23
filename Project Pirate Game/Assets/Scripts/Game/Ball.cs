using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private GameObject Explosion;
    [HideInInspector] public Transform Owner;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Owner != collision.transform && collision.transform.TryGetComponent<LifeSystem>(out var Life))
            Life.Hit(Damage);

        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
