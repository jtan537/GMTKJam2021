using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Horizontal Movement Variables")]
    [SerializeField] private float XInput = 0;
    [SerializeField] private float XMovement = 0;
    public float moveSpeed = 5f;
    public float acceleration = 0.2f;

    [Header("Jumping Variables")]
    [SerializeField] private GroundCheck groundCheck;
    public float jumpForce = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck").gameObject.GetComponent<GroundCheck>();;
    }

    // Update is called once per frame
    void Update()
    {
        // Get X axis input
        XInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate(){
        XMovement = Mathf.Lerp(XMovement, XInput, acceleration);
        rb.velocity = new Vector2(XMovement * moveSpeed * Time.deltaTime, rb.velocity.y);
        // rb.velocity = new Vector2(XInput * moveSpeed * Time.deltaTime, rb.velocity.y);


        if(Input.GetKey(KeyCode.Space) && groundCheck.isGrounded){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
