using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float Hight = 1;

    void Update()
    {
        Vector3 Pos = Target.position;
        Pos.y -= -Hight;

        transform.position = Pos;
    }
}
