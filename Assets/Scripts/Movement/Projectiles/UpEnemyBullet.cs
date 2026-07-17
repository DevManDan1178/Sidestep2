using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpEnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
