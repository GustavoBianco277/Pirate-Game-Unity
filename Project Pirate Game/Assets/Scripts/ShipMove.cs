using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMove : MonoBehaviour
{
    [SerializeField] Camera Cam;
    [SerializeField] KeyCode MoveKey = KeyCode.W;
    [SerializeField] float Velocity = 10;
    //[SerializeField][Range(1, 100)] float VelocityAngular = 100;
    [SerializeField] float CamDistenceShip = 6;

    // privates
    private Rigidbody2D Rigid;
    
    private Vector3 MousePos;
    void Start()
    {
        Rigid = Rigid ? Rigid : GetComponent<Rigidbody2D>();
        
        Cam = Cam ? Cam : Camera.main;
    }

    void Update()
    {
        //Cam.transform.position = new Vector3(transform.position.x, transform.position.y, CamDistenceShip);
        MousePos = Input.mousePosition;
        MousePos.z = transform.position.z;

        transform.up = -(MousePos - transform.position);

        if (Input.GetKey(MoveKey) && Rigid.velocity.magnitude < Velocity)
        {
            Rigid.AddForce(-transform.up * Rigid.mass * 100 * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
