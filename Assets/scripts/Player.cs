using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    public bool isGrounded = false;
    public float checkGroundOffsetY = -1.8f;
    public float checkGroundRadius = 0.3f;
    public Animator animator;
    public BlackScreen BlackScreen;
    public GameObject mapStarter;
    float moveHorizontal;
    private Iinteract interact;
    Rigidbody2D rb;
    SpriteRenderer sr;
    public bool CanMove;
    public static Player instancePlayer { get; private set; }
    private void Awake()
    {
        if (instancePlayer == null)
        {
            instancePlayer = this;
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(this.gameObject);
    }
    void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnSceneUnloaded(Scene scene)
    {
        mapStarter = GameObject.FindGameObjectWithTag("mapObject");
    }
    private void Update()
    {
        if(interact != null && Input.GetKeyDown(KeyCode.E))
        {
            interact.interact();
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        moveHorizontal = CanMove ? ( Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0) : 0;

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
        interact = collision.GetComponent<Iinteract>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interact = null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
        animator.SetBool("Jumping", false);
    }
}