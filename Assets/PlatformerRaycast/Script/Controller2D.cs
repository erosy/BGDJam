using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller2D : RaycastController
{
    public LayerMask collisionMask;
    public CollisionInfo collisions;
    Vector2 playerInput;
    private Player player;
    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
        collisions.faceDirection = 1;
    }
    private void HorizontalCollisions(ref Vector2 moveAmount)
    {
        float directionX = collisions.faceDirection;
        float rayLength = Mathf.Abs(moveAmount.x) + skinWidth;

        if (Mathf.Abs(moveAmount.x) < skinWidth)
            rayLength = 2 * skinWidth;

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);

            if (hit)
            {
                if (hit.distance == 0)
                    continue;

                if (hit.collider.tag == "hitbox")
                {
                    if (!collisions.gotHit)
                    {

                        if (player.life != 0)
                        {
                            collisions.gotHit = true;
                            player.life--;
                            this.transform.position = player.spawnTransform.position;
                        }

                        else
                        {
                            Destroy(this.gameObject);
                        }
                        Invoke(nameof(ResetHitStatus), 2f);
                        continue;


                    }
                    else
                        continue;
                }


                    moveAmount.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;

                collisions.left = directionX == -1;
                collisions.right = directionX == 1;
            }

        }
    }

    private void VerticalCollisions(ref Vector2 moveAmount)
    {
        float directionY = Mathf.Sign(moveAmount.y);
        float rayLength = Mathf.Abs(moveAmount.y) + skinWidth;
        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

            if (hit)
            {
                if (hit.collider.tag == "Through")
                {
                    if (directionY == 1 || hit.distance == 0)
                        continue;

                    if (collisions.fallingThroughPlatform)
                        continue;

                    if (playerInput.y == -1)
                    {
                        collisions.fallingThroughPlatform = true;
                        Invoke(nameof(ResetFallingThroughPlatform), .5f);
                        continue;
                    }
                        
                }

                if (hit.collider.tag == "Trampoline")
                {
                    collisions.isTouchingTrampoline = true;
                    Invoke(nameof(ResetTouchingTrampoline), .5f);
                }

                if(hit.collider.tag == "hitbox")
                {
                    if (!collisions.gotHit)
                    {

                        if (player.life != 0)
                        {
                            collisions.gotHit = true;
                            player.life--;
                            this.transform.position = player.spawnTransform.position;
                        }

                        else
                        {
                            Destroy(this.gameObject);
                        }
                        Invoke(nameof(ResetHitStatus), 2f);
                        continue;
                       
                        
                    }
                    else
                        continue;
                  

                   
                }
                    
        

                moveAmount.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;

                collisions.below = directionY == -1;
                collisions.above = directionY == 1;
            }

        }
    }

  
    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;
        public bool fallingThroughPlatform;
        public bool isTouchingTrampoline;
        public bool gotHit;
        public int faceDirection;
        public void Reset()
        {
            above = below = false;
            left = right = false;
        }
    }

    public void Move(Vector2 moveAmount, bool standingOnPlatform)
    {
        Move(moveAmount, Vector2.zero, standingOnPlatform);
    }
    public void Move(Vector2 moveAmount, Vector2 input, bool standingOnPlatform = false)
    {
        UpdateRaycastOrigins();
        collisions.Reset();
        playerInput = input;
        if (moveAmount.x != 0)
        {
            collisions.faceDirection = (int)Mathf.Sign(moveAmount.x);
           
        }
        //Calculate collisions horizontal first sebelum vertical karena ntr ganggu
        HorizontalCollisions(ref moveAmount);
        if (moveAmount.y != 0)
            VerticalCollisions(ref moveAmount);      
        transform.Translate(moveAmount);
        if (standingOnPlatform)
            collisions.below = true;
    }

    void ResetFallingThroughPlatform() => collisions.fallingThroughPlatform = false;
    void ResetTouchingTrampoline() => collisions.isTouchingTrampoline = false;
    void ResetHitStatus() => collisions.gotHit = false;
  

}
