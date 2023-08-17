using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0;
    int numberOfJumps = 0;
    bool isFacingRight = true;//by default player face's right
    bool isGrounded;//check player is on ground 


    [SerializeField] float speed = 400;
    public float jumpForce = 5;

    public Rigidbody2D playerRB;
    public Animator animator;
    public Transform groundCheck;
    public LayerMask groundLayer;//add layerMask to groudPlayer so that overlapcircle can differentiate from player

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        //check if move is performed
        controls.Land.Move.performed += ctx =>
        {
            //if move action is performed this code is called.
            direction = ctx.ReadValue<float>(); //ctx.ReadValue returns 1 if we hit right arrow and -1 if left arrow. If the keys are released it returns 0(zero)
        };

        //check if jump is performed
        controls.Land.Jump.performed += ctx => Jump();
    }

    // using FixedUpdate while using physics to run smoother
    void FixedUpdate()
    {
        //check if player is touching ground. 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        //Debug.Log("isGrounded :" + isGrounded);
        animator.SetBool("isGrounded", isGrounded);//if isGrounded false play jump animation

        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);

        //if direction value is 1 or -1 ,means moving. 
        //if speed parameter greater than 0.1 player Run animation is played,if less than 0.1 Idle animation is played  
        animator.SetFloat("speed", Mathf.Abs(direction)); //set speed parameter with respect to direction value

        //make character flip to left on moving backwards(i.e direction is -1) and vice versa.
        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();
    }

    /// <summary>
    /// flip player based on current facing orientation
    /// </summary>
    void Flip()
    {
        //Debug.Log("Flip");
        isFacingRight = !isFacingRight;
        //if scale x is 1 it changes to -1 and vice versa.
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            //Debug.Log("Jump if grounded");
            numberOfJumps = 0;//reset numberOfJumps to zero on reaching ground
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("FirstJump");
        }
        else
        {
            if (numberOfJumps == 1)//if numberofJumps is 1 perform double jump
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;//check if you go for 3rd jump before hitting ground,hence denying it
                AudioManager.instance.Play("SecondJump");
            }
        }
    }
}

