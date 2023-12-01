using UnityEngine;

public class AntHunt : MonoBehaviour
{
    private RaycastHit2D hit;
    private Vector3 PlayerTransform;
    private bool Move;
    private MovePointToPoint MoveScript;
    [SerializeField] float speed;
    [SerializeField] private float range;
    private void Start()
    {
        MoveScript = GetComponent<MovePointToPoint>();
    }
    private void Update()
    {
        if (hit = Physics2D.Raycast(transform.position, -transform.right, range, 1))
        {
            if(hit.collider.tag == "Player")
            {
                MoveScript.DoMove = false;
                PlayerTransform = hit.collider.gameObject.transform.position;
                Move = true;
            }
        }
        if (hit = Physics2D.Raycast(transform.position, transform.right, range, 1))
        {
            if (hit.collider.tag == "Player")
            {
                MoveScript.DoMove = false;
                PlayerTransform = hit.collider.gameObject.transform.position;
                Move = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if(Move)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(PlayerTransform.x, transform.position.y), speed);
        }
        if (transform.position.x == PlayerTransform.x)
        {
            MoveScript.DoMove = true;
            Move = false;
        }
    }
}
