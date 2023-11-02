using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 1f;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public float checkGroundOffsetY = -1.8f;
    public float checkGroundRadius = 0.3f;
    public Animator animator;
    public BlackScreen gam;

    Rigidbody2D rb;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            gam.StartBlackScreen();
        }

        animator.SetFloat("HorizontalMove", Mathf.Abs(movement));

        sr.flipX = movement < 0 ? true : false;

        if(isGrounded == false)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        CheckGround();
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);

        if(colliders.Length > 1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


}