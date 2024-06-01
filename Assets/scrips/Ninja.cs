using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float jumpForce;
    public float speed;
    public float lastJumpYPosition;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            lastJumpYPosition = transform.position.y;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
