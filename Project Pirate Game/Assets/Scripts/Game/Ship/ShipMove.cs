using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMove : MonoBehaviour
{
    [Tooltip("Main camera")]
    [SerializeField] private Camera Cam;

    [Tooltip("Key to move ship")]
    [SerializeField] private KeyCode MoveKey = KeyCode.W;

    [Tooltip("Ship speed")]
    [SerializeField] private float Velocity = 50;

    [Tooltip("Ship turning speed")]
    [SerializeField][Range(0, 1)] private float VelocityAngular = 0.1f;

    public bool Active = true; // Active move

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
        if (Active)
        {
            MousePos = Input.mousePosition;
            MousePos.z = 10;
            MousePos = Cam.ScreenToWorldPoint(MousePos);

            //transform.up = MousePos - transform.position;
            transform.up = Vector3.Lerp(transform.up, MousePos - transform.position, Time.deltaTime * VelocityAngular);

            if (Input.GetKey(MoveKey) && Rigid.velocity.magnitude < Velocity)
            {
                Rigid.AddForce(transform.up * Rigid.mass * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }
}
