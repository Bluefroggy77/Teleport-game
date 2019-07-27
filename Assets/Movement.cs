using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumpForce;
    public float gravity;
    public bool canJump;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {       
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            if (hit.collider.tag == "Solid")
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }
        else
        {
            canJump = false;
        }      

        rb.AddForce(new Vector3(0, gravity, 0));
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            walk(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            walk(false);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(rb.velocity.x/1.4f, rb.velocity.y, 0);
        }
    }
    void walk(bool left)
    {
        if (left == false)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
        }
        if (left == true)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
        }
    }
}
