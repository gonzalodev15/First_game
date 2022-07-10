using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody rb;
    public bool isGrounded;
    public static Action PlayerDied;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(xMove, rb.velocity.y, zMove) * speed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 jump = new Vector3(0.0f, 4f, 0.0f);
            rb.AddForce(jump, ForceMode.Impulse);
            isGrounded = false;
        }

        if (rb.velocity.y < -10)
        {
            PlayerDied?.Invoke();
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
}
