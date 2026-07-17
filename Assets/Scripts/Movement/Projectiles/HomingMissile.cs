using UnityEngine;
 [RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    private Transform target;

    public GameObject CollisionEffect;

    public float rotateSpeed = 200f;

    public float speed = 5f;

    public float chaseOrOrbit = 1f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = GameObject.FindWithTag("Player")?.transform;
        if (target == null)
        {
            return;
        }
        Vector2 direction = (Vector2)target.position - rb.position;
        
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;
    
        rb.linearVelocity = transform.up * chaseOrOrbit* speed;

    
    }
    void OnTriggerEnter2D ()
    {
    Instantiate(CollisionEffect, transform.position, transform.rotation);
    }
}

