using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    private bool isGrounded = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) rb.AddForce(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.S)) rb.AddForce(Vector3.back * speed);
        if (Input.GetKey(KeyCode.A)) rb.AddForce(Vector3.left * speed);
        if (Input.GetKey(KeyCode.D)) rb.AddForce(Vector3.right * speed);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            if (GameManager.instance != null)
            {
                GameManager.instance.CollectItem();
            }
        }
    }
}