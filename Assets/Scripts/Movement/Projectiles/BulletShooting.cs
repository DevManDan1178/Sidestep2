using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{   
    private Vector3 mousePosition;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        Vector3 rotation = transform.position - mousePosition;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }
}
