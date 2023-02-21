using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    [SerializeField] Transform Alvo;
    [SerializeField] float Hight = 1;

    void Update()
    {
        Vector3 Pos = Alvo.position;
        Pos.y -= -Hight;

        transform.position = Pos;
    }
}
