using UnityEngine;
using DG.Tweening;

public class LifeSystem : MonoBehaviour
{
    [Tooltip("The ship is mine ? (Player)")]
    public bool IsMine;

    [Tooltip("Life of ship")]
    [SerializeField] private float Life = 100;

    [Tooltip("Duration to apply the damage of life bar")]
    [SerializeField] private float Duration = 1;

    [Tooltip("Score of Ship")]
    [SerializeField] private int Score = 10;

    [Tooltip("Life bar")]
    [SerializeField] private Transform FillBar;

    [Tooltip("Explosion effect")]
    [SerializeField] private GameObject Explosion;

    [Tooltip("Ship damage sprites")]
    [SerializeField] private Sprite[] ShipStage;

    [HideInInspector] public bool Destroyed; // Destroyed ship

    // privates
    private SpriteRenderer Ship;
    private Status Status;
    private Rigidbody2D Rigid;
    private CapsuleCollider2D Collider;

    void Start()
    {
        Ship = GetComponent<SpriteRenderer>();
        Status = FindObjectOfType<Status>();
        Rigid = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
    }

    public void Hit(int Damage)
    {
        Life -= Damage;
        float LifeValue = Life / 100;
        LifeValue = LifeValue > 0 ? LifeValue : 0;

        FillBar.parent.gameObject.SetActive(true);
        FillBar.DOScaleX(LifeValue, Duration);

        ShipStages();
    }

    private void ShipStages()
    {
        switch (Life)
        {
            case <= 0:
            {
                Ship.sprite = ShipStage[0];
                DestroyShip();
                break;
            }
            case <= 35:
            {
                Ship.sprite = ShipStage[1];
                break;
            }
            case <= 70:
            {
                Ship.sprite = ShipStage[2];
                break;
            }
            default:
            {
                Ship.sprite = ShipStage[3];
                break;
            }
        }
    }

    private void DestroyShip()
    {
        GameObject Obj = Instantiate(Explosion, transform.position, transform.rotation);
        Obj.transform.localScale = Vector3.one * 2;
        FillBar.parent.gameObject.SetActive(false);

        DisableShip(true);

        if (IsMine)
            Status.ActivePanel("Game Over");

        else
        {
            Status.Score += Score;

            foreach (SpriteRenderer Sr in GetComponentsInChildren<SpriteRenderer>())
            {
                Sr.DOFade(0, 5).OnComplete(() => Destroy(transform.parent.gameObject));
            }
        }
    }

    public void DisableShip(bool status)
    {
        Destroyed = status;
        Rigid.simulated = !status;
        Collider.enabled = !status;

        if (!status)
        {
            FillBar.localScale = Vector3.one;
            FillBar.parent.gameObject.SetActive(false);
            Life = 100;
            ShipStages();
        }

        if (TryGetComponent<ShipMove>(out var Ship))
            Ship.Active = !status;

        else if (TryGetComponent<ShooterEnemy>(out var ShipEnemy))
            Destroy(ShipEnemy);
    }
}
