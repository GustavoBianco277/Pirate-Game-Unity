
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] float Life = 100;
    [SerializeField] float Duration = 1;
    [SerializeField] Transform FillBar;
    [SerializeField] GameObject Explosion;
    [SerializeField] Sprite[] ShipStage;

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

        //FillBar.localScale = new Vector3(LifeValue, 1, 1);
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
        GameObject Obj = Instantiate(Explosion, transform.position, transform.rotation);
        Obj.transform.localScale = Vector3.one * 2;
        FillBar.parent.gameObject.SetActive(false);
        GetComponent<ShipMove>().Active = false;
    }
}
