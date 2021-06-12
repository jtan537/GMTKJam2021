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

    [Header("Interactables Variables")]
    [SerializeField] private InteractablesCheck InteractablesCheck;

    [Header("Animation Variables")]
    [SerializeField] private Animator anim;
    [SerializeField] private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        groundCheck = transform.Find("GroundCheck").gameObject.GetComponent<GroundCheck>();
        
        // Use interactablesCheck.packageInRange to determine if player can pick up package
        InteractablesCheck = transform.Find("InteractablesCheck").gameObject.GetComponent<InteractablesCheck>();

    }

    // Update is called once per frame
    void Update()
    {
        // Get X axis input
        XInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate(){

        // Movement code
        XMovement = Mathf.Lerp(XMovement, XInput, acceleration);
        rb.velocity = new Vector2(XMovement * moveSpeed * Time.deltaTime, rb.velocity.y);
        
        if(Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded){
            Debug.Log("jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Start jump animation
            // anim.SetBool("startingJump", true);
        }

        // Animator code

        // Check if running animation should play 
        if(XInput != 0){
            anim.SetBool("isRunning", true);
        }else{
            anim.SetBool("isRunning", false);
        }

        // Flip player sprite based on direction
        if(XMovement > 0){
            //tr.localScale = new Vector3(1f, 1f, 1f );
            GameObject.Find("Stack").transform.localPosition = new Vector3(0, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(XMovement < 0 ){
            //tr.localScale = new Vector3(-1f, 1f, 1f);
            GameObject.Find("Stack").transform.localPosition = new Vector3(-1, 0, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        // Pass y velocity to anim, checks if player is falling
        anim.SetFloat("YVelocity", rb.velocity.y);
        anim.SetBool("touchingGround", groundCheck.isGrounded);
        }
}
