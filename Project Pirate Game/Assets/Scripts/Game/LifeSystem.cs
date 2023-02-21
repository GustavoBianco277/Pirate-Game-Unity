
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] float Life = 100;
    [SerializeField] Transform FillBar;
    [SerializeField] Sprite[] ShipStage;
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

        FillBar.localScale = new Vector3(LifeValue, 1, 1);
        
        switch (Life)
        {
            case <= 0:
            {
                Ship.sprite = ShipStage[0];
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
}
