
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] int Life = 100;
    [SerializeField] Slider LifeSlider;
    [SerializeField] Sprite[] ShipStage;
    private Image Ship;

    void Start()
    {
        Ship = GetComponent<Image>();
    }

    public void Hit(int Damage)
    {
        Life -= Damage;
        LifeSlider.value = Life;
        
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
