using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] int Damage;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<LifeSystem>())
            collision.transform.GetComponent<LifeSystem>().Hit(Damage);

        GetComponent<Rigidbody2D>().simulated = false;
        Destroy(gameObject);
    }
}
