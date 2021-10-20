using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Class isinya konfigurasi dan properti entity enemy, yang bakal di inherit
    public FiniteStateMachine stateMachine;

    public D_Entity entityData;
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    public GameObject aliveGO { get; private set; }
    public int facingDirection { get; private set; }
    private Vector2 velocityWorkSpace;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;
    public virtual void Start()
    {
        facingDirection = 1;
        aliveGO = transform.Find("Alive").gameObject;
        rb = aliveGO.GetComponent<Rigidbody2D>();
        anim = aliveGO.GetComponent<Animator>();

        stateMachine = new FiniteStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
       // Debug.Log(WallDetected());
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkSpace.Set(facingDirection * velocity, rb.velocity.y);
        rb.velocity = velocityWorkSpace;
    }

    public virtual bool WallDetected()
    {
        var detectingWall = Physics2D.Raycast(wallCheck.position, aliveGO.transform.right, entityData.wallCheckDistance, entityData.whatIsGround);
        if (detectingWall)
        {
            if (detectingWall.collider.CompareTag("hitbox"))
                return false;
            else
                return
                    true;
        }
        return false;
    }
    public virtual bool LedgeDetected()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, entityData.ledgeCheckDistance, entityData.whatIsGround);

    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        var detectingPlayer = Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
        if (detectingPlayer)
        {
            var player = detectingPlayer.collider.GetComponent<Player>();
            if (player.isDied)
                return false;
            else
                return true;
        }
        return false;
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
       var detectingPlayer = Physics2D.Raycast(playerCheck.position, aliveGO.transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
        if (detectingPlayer)
        {
            var player = detectingPlayer.collider.GetComponent<Player>();
            if (player.isDied)
                return false;
            else
                return true;
        }
        return false;
    }


    public virtual void Flip()
    {
        facingDirection *= -1;
        aliveGO.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector2.right * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector2.down * entityData.ledgeCheckDistance));
    }

}
