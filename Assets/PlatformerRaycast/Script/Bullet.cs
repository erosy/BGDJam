using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    //private float direction;
    public float bulletDuration;
    private float bulletTimer;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        bulletTimer = bulletDuration;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left /* direction*/ * speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletTimer = bulletDuration;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.left /* direction*/ * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //direction = Mathf.Sign(transform.localScale.x);
        bulletTimer -= Time.deltaTime;
        if (bulletTimer <= 0)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("CameraTrigger"))
            bulletTimer = 0;
    }
}
