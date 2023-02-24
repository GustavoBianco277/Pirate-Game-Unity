using UnityEngine;

public class FollowShip : MonoBehaviour
{
    [Tooltip("Target to follow")]
    [SerializeField] Transform Target;

    [Tooltip("Bar Height")]
    [SerializeField] float Height = 1;

    void Update()
    {
        Vector3 Pos = Target.position;
        Pos.y -= -Height;

        transform.position = Pos;
    }
}
