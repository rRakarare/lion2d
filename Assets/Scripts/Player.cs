using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float speed;

    private float input;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update() {

        jump();

        if (input != 0) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
        
        if (input > 0) {
            transform.eulerAngles = new Vector3(0,0,0);
        } else if (input < 0) {
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    void FixedUpdate() {
        input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);
        
        
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
