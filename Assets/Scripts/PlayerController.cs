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

    private bool canJump = false;

    [Header("Particles")]
    [SerializeField] public GameObject runParticlesR;
    [SerializeField] public GameObject runParticlesL;
    [SerializeField] public ParticleSystem jumpParticles;

    [Header("Personal Audio")]
    [SerializeField] private AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("LevelTheme");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        groundCheck = transform.Find("GroundCheck").gameObject.GetComponent<GroundCheck>();
        
        // Use interactablesCheck.packageInRange to determine if player can pick up package
        InteractablesCheck = transform.Find("InteractablesCheck").gameObject.GetComponent<InteractablesCheck>();

        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get X axis input
        XInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && groundCheck.isGrounded)
        {
            canJump = true;
            PlayJumpParticles();        }
    }

    void FixedUpdate(){

        // Movement code
        XMovement = Mathf.Lerp(XMovement, XInput, acceleration);
        rb.velocity = new Vector2(XMovement * moveSpeed * Time.deltaTime, rb.velocity.y);
        
        if (canJump)
        {
            canJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.instance.Play("Jump");

        }
            

            // Start jump animation
            // anim.SetBool("startingJump", true);

        // Animator code

        // Check if running animation should play 
        if(XInput != 0 && groundCheck.isGrounded){     
            //runParticles.SetActive(true);
            anim.SetBool("isRunning", true);

            // Play walking SFX
            if(!src.isPlaying){
                src.Play();
            }
        }else{
            anim.SetBool("isRunning", false);
            runParticlesR.SetActive(false);
			runParticlesL.SetActive(false);

            src.Stop();
        }


        // Flip player sprite based on direction
        if(XMovement > 0){
            //tr.localScale = new Vector3(1f, 1f, 1f );
			runParticlesR.SetActive(true);
			runParticlesL.SetActive(false);
            GameObject.Find("Stack").transform.localPosition = new Vector3(.4f, .2f, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
			
        }
        else if(XMovement < 0 ){
            //tr.localScale = new Vector3(-1f, 1f, 1f);
			runParticlesL.SetActive(true);
			runParticlesR.SetActive(false);
            GameObject.Find("Stack").transform.localPosition = new Vector3(-1.4f, .2f, 0);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }


        // Pass y velocity to anim, checks if player is falling
        anim.SetFloat("YVelocity", rb.velocity.y);
        anim.SetBool("touchingGround", groundCheck.isGrounded);
        }

        public void PlayJumpParticles(){
            jumpParticles.Play();
        }
}
