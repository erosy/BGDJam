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
    private AudioSource audioSource;

    [Header("Health Configuration")]
    public int life = 3;

   
    float maxJumpVelocity;
    float minJumpVelocity;
    float gravity;
    float velocityXSmoothing;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float timeToWallUnstick;
    float jumpPressedResetDuration = .1f;
    [Header("Movement Configuration")]
    public float jumpPressedResetTime;
    public float trampolineJumpMultiplier;
    public float moveSpeed = 5;
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    public float wallSlideToMax = 3f;
    public float wallStickTime = 1f;
    public Vector2 inputDirection;
    //public Vector2 trampolineVelocity;
    //public Vector2 wallJumpClimb;
    //public Vector2 wallJumpOff;
    //public Vector2 wallJumpLeap;
    public bool jumpPressed;
    public bool directionPressed;
    //bool wallSliding;
    //int wallDirX;
    Vector2 velocity;
    Controller2D controller2D;
    // Start is called before the first frame update
    void Start()
    {
        controller2D = GetComponent<Controller2D>();
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        audioSource = GetComponent<AudioSource>();
        //print("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        //Move the Player
        CalculateMoveVelocity();
        //Jumping
        JumpKeyDown();
        //Counting Teleport Cooldown
        TeleportCooldown();
        controller2D.Move(velocity * Time.deltaTime, inputDirection);

        if (controller2D.collisions.above || controller2D.collisions.below)
            velocity.y = 0;
    }

    #region Move Function(s)
    private void CalculateMoveVelocity()
    {
        directionPressed = (inputDirection != Vector2.zero) ? true : false;
        float targetVelocityX = inputDirection.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller2D.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;

        if (controller2D.collisions.isTouchingTrampoline)
            velocity.y = /*Vector3.Lerp(trampolineVelocity, Vector3.zero, 10 * Time.deltaTime);*/ trampolineJumpMultiplier * maxJumpVelocity; 
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
           
            if (controller2D.collisions.below)
                velocity.y += maxJumpVelocity;
        }   
    }

    public void ResetJumpPressed() =>  jumpPressed = false;
    #endregion
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

    #region lain-lain
    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    #endregion

}
