using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    //private float direction;
    public float bulletDuration;
    [HideInInspector]public Vector2 shootingDirection;
    [SerializeField] private GameObject bulletSprite;
    private float bulletTimer;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        bulletTimer = bulletDuration;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = shootingDirection * speed;
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletTimer = bulletDuration;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = shootingDirection  /* direction*/ * speed;
        Vector2 velocity = rb.velocity;
        var angle = Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg;
        bulletSprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
       // Debug.Log(collision.name);
        if (!collision.CompareTag("CameraTrigger"))
            bulletTimer = 0;
        //if (collision.CompareTag("Player"))
        //    collision.gameObject.GetComponent<Player>().KillPlayer();
    }
}
