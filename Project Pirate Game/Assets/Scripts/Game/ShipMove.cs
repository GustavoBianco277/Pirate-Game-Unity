using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMove : MonoBehaviour
{
    [SerializeField] Camera Cam;
    [SerializeField] KeyCode MoveKey = KeyCode.W;
    [SerializeField] float Velocity = 50;
    [SerializeField][Range(1, 100)] float VelocityAngular = 100;
    //[SerializeField] float CamDistenceShip = 6;

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
        MousePos = Input.mousePosition;
        MousePos.z = 10;
        MousePos = Cam.ScreenToWorldPoint(MousePos);
        print(MousePos);
        
        //transform.up = MousePos - transform.position;
        transform.up = Vector3.Lerp(transform.up, MousePos - transform.position, Time.deltaTime * VelocityAngular /10);

        //Cam.transform.position = new Vector3(transform.position.x, transform.position.y, -CamDistenceShip);

        if (Input.GetKey(MoveKey) && Rigid.velocity.magnitude < Velocity)
        {
            Rigid.AddForce(transform.up * Rigid.mass * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
