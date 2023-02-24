using UnityEngine;

public class Ball : MonoBehaviour
{
    [Tooltip("Projectile damage")]
    [SerializeField] private int Damage;

    [Tooltip("Explosion effect")]
    [SerializeField] private GameObject Explosion;

    [HideInInspector] public Transform Owner; // Projectile owner

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Owner != collision.transform && collision.transform.TryGetComponent<LifeSystem>(out var Life))
        {
            if (!Life.Destroyed)
                Life.Hit(Damage);
        }

        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
