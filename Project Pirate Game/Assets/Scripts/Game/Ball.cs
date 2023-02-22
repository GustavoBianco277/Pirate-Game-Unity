using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] int Damage;
    [SerializeField] GameObject Explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<LifeSystem>(out var Life))
            Life.Hit(Damage);

        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
