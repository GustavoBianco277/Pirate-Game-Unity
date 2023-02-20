using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    [SerializeField] Transform Alvo;

    void Update()
    {
        Vector3 Pos = Alvo.position;
        Pos.y -= -60;

        transform.position = Pos;
    }
}
