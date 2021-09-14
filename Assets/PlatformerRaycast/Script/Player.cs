using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Controller2D))]
public class Player : MonoBehaviour
{
    [Header("Interaction Configuration")]
    public bool isInteractable = false;
    public GameObject interactableObject;
    public Transform portalTransform;
    public Transform spawnTransform;
    [SerializeField] private float cooldownDuration;
    private float timer;

    [Header("Health Configuration")]
    public int life = 3;

    [Header("Movement Configuration")]
    float maxJumpVelocity;
    float minJumpVelocity;
    float gravity;
    float velocityXSmoothing;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float timeToWallUnstick;
    float jumpPressedResetDuration = .1f;
    public float jumpPressedResetTime;
    public float moveSpeed = 5;
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    public float wallSlideToMax = 3f;
    public float wallStickTime = 1f;
    public Vector2 inputDirection;
    public Vector2 trampolineVelocity;
    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallJumpLeap;
    public bool jumpPressed;
    public bool directionPressed;
<<<<<<< Updated upstream
    bool wallSliding;
    int wallDirX;
=======
    public bool cannotMove;
    public bool isDied;
    //bool wallSliding;
    //int wallDirX;
    public bool flip;
    public int direction = 1;
>>>>>>> Stashed changes
    Vector2 velocity;
    Controller2D controller2D;
    // Start is called before the first frame update
    void Start()
    {
        controller2D = GetComponent<Controller2D>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        //print("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        //Move the Player
        CalculateMoveVelocity();
        //WallSliding
        HandleWallSliding();
        //Jumping
        JumpKeyDown();
        //Counting Teleport Cooldown
        TeleportCooldown();
        controller2D.Move(velocity * Time.deltaTime, inputDirection);

        if (controller2D.collisions.above || controller2D.collisions.below)
            velocity.y = 0;
=======
        if (!cannotMove && !isDied)
        {
            //Move the Player
            CalculateMoveVelocity();
            //Jumping
            JumpKeyDown();
            //Counting Teleport Cooldown
            TeleportCooldown();
            DoingFlip();


        }
        else
        {
            anim.SetBool("isRun", false);
            velocity.x = 0;
        }
        
        controller2D.Move(velocity * Time.deltaTime, inputDirection);
        if (controller2D.collisions.above || controller2D.collisions.below)
            velocity.y = 0;
        velocity.y += gravity * Time.deltaTime;
        directionPressed = (inputDirection != Vector2.zero && !cannotMove) ? true : false;
        anim.SetBool("isGround", controller2D.collisions.below);
        anim.SetBool("isDie", isDied);
       

>>>>>>> Stashed changes
    }

    #region Move Function(s)
    private void CalculateMoveVelocity()
    {
<<<<<<< Updated upstream
        directionPressed = (inputDirection != Vector2.zero) ? true : false;
=======
        anim.SetBool("isRun", directionPressed);
>>>>>>> Stashed changes
        float targetVelocityX = inputDirection.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller2D.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
       
        if (controller2D.collisions.isTouchingTrampoline)
            velocity.y = /*Vector3.Lerp(trampolineVelocity, Vector3.zero, 10 * Time.deltaTime);*/maxJumpVelocity; 
    }
    #endregion
    #region Jump Function(s)
    //agar bisa disesuaikan jumpnya mau tinggi atau rendah
    public void JumpKeyUp()
    {
        if (jumpPressed)
        {
            if (velocity.y > minJumpVelocity)
                velocity.y = minJumpVelocity;
        }
       
    }

    public void JumpKeyDown()
    {
        //Untuk Lompat
        if (jumpPressed)
        {
            Invoke(nameof(ResetJumpPressed), 0.2f);
            if (wallSliding)
            {
                if (wallDirX == inputDirection.x)
                    velocity = new Vector2(-wallDirX * wallJumpClimb.x, wallJumpClimb.y);
                else if (inputDirection.x == 0)
                    velocity = new Vector2(-wallDirX * wallJumpOff.x, wallJumpOff.y);
                else
                    velocity = new Vector2(-wallDirX * wallJumpLeap.x, wallJumpLeap.y);
            }

            if (controller2D.collisions.below)
                velocity.y += maxJumpVelocity;
        }   
    }

    public void ResetJumpPressed() =>  jumpPressed = false;

    #region Player Abilities
    public void InteractObject()
    {
        if (isInteractable && interactableObject != null)
            interactableObject.GetComponent<AbstractInteractables>().Interactables();

    }

    public void Teleport()
    {
        if(portalTransform != null && timer == 0)
        {
            this.transform.position = portalTransform.transform.position;
            timer = cooldownDuration;
        }
        else
        {
            Debug.Log("You haven't activated the portal!");
        }
    }

    private void TeleportCooldown()
    {
        if (timer > 0f)
            timer -= Time.deltaTime;
        if (timer < 0f)
            timer = 0;
    }
    #endregion
    #endregion
    #region Wall Slide Function(s)
    private void HandleWallSliding()
    {
        wallSliding = false;
        wallDirX = (controller2D.collisions.left) ? -1 : 1;
        if ((controller2D.collisions.left || controller2D.collisions.right) && directionPressed && !controller2D.collisions.below && velocity.y < 0)
        {
            wallSliding = true;
            if (velocity.y < -wallSlideToMax)
                velocity.y = -wallSlideToMax;
            if (timeToWallUnstick > 0)
            {
                velocity.x = 0;
                velocityXSmoothing = 0;

                if (inputDirection.x != wallDirX && inputDirection.x != 0)
                    timeToWallUnstick -= Time.deltaTime;
                else
                    timeToWallUnstick = wallStickTime;
            }
            else
                timeToWallUnstick = wallStickTime;
        }

    }
    #endregion
}
