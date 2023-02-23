
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LifeSystem : MonoBehaviour
{
    [Tooltip("The ship is mine ? (Player)")]
    public bool IsMine;
    [Tooltip("Life of ship")]
    [SerializeField] float Life = 100;
    [Tooltip("Duration to apply the damage of life bar")]
    [SerializeField] float Duration = 1;
    [Tooltip("Life bar")]
    [SerializeField] Transform FillBar;
    [Tooltip("Explosion effect")]
    [SerializeField] GameObject Explosion;
    [Tooltip("Ship damage sprites")]
    [SerializeField] Sprite[] ShipStage;
    [HideInInspector] public bool Destroyed; // Destroyed ship

    // privates
    private SpriteRenderer Ship;

    void Start()
    {
        Ship = GetComponent<SpriteRenderer>();
    }

    public void Hit(int Damage)
    {
        Life -= Damage;
        float LifeValue = Life / 100;
        LifeValue = LifeValue > 0 ? LifeValue : 0;

        FillBar.parent.gameObject.SetActive(true);
        FillBar.DOScaleX(LifeValue, Duration);
        
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
        }
    }
    private void DestroyShip()
    {
        Destroyed = true;
        GameObject Obj = Instantiate(Explosion, transform.position, transform.rotation);
        Obj.transform.localScale = Vector3.one * 2;
        FillBar.parent.gameObject.SetActive(false);

        if (TryGetComponent<ShipMove>(out var Ship))
            Ship.Active = false;
    }
}
