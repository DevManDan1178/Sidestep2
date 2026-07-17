using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{    private Rigidbody2D rb;
    public float Speed = 5f;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }
}
