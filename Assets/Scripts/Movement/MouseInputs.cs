using UnityEngine;

public class MouseInputs : MonoBehaviour
{
    public float rotationspeed = 5;
    public float speed = 3f;
    private Vector3 target;
    public float screenMovementSpeedUp = 0f;
    public float screenMovementSpeedRight = 0f;
    private bool startedMoving = false;
    


    // Update is called once per frame

    void Start()
    {
        target = transform.position;
    }
    



    void Update()
    {
        
        //Mouse click and position
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Mouse - Right Click");

            Debug.Log(Input.mousePosition);
            //ScreenToWorldPoint = world coordinates
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            startedMoving = true;

        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (startedMoving)
        {
            target.x += screenMovementSpeedRight * Time.deltaTime;
            target.y += screenMovementSpeedUp * Time.deltaTime;
        }
        if (target != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, target);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            target = transform.position;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse - Left Click");

            Debug.Log(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Mouse - Scroll Click");

            Debug.Log(Input.mousePosition);
        }
    }
}
