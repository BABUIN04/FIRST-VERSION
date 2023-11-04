using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public float checkGroundOffsetY = -1.8f;
    public float checkGroundRadius = 0.3f;
    public Animator animator;
    public BlackScreen BlackScreen;
    float moveHorizontal;
    bool IsInTrigger = false;

    Rigidbody2D rb;
    SpriteRenderer sr;

    void Awake()
    {

        DontDestroyOnLoad(this);

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if(IsInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(BlackScreen.BlackScreenFunc());
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        moveHorizontal = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        transform.Translate(movement * speed * Time.fixedDeltaTime);

        animator.SetFloat("HorizontalMove", Mathf.Abs(moveHorizontal));
        sr.flipX = moveHorizontal < 0 ? true : false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        animator.SetBool("Jumping", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "interactable")
        {
            IsInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsInTrigger = false;
    }
    //Ќадо переработать как получу ответ с форума
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
        animator.SetBool("Jumping", false);
    }
}