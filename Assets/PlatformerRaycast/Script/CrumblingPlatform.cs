    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : RaycastController
{
    [SerializeField] private LayerMask playerMask;
    

    // Update is called once per frame
    void Update()
    {
        UpdateRaycastOrigins();
        VerticalCollisions();
    }

    private void VerticalCollisions()
    {
        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up, skinWidth, playerMask);

            Debug.DrawRay(rayOrigin, Vector2.up * skinWidth, Color.red);

            if (hit)
            {
                Invoke(nameof(DeactivateObject), 1f);
            }

        }
    }


    private void DeactivateObject() => this.gameObject.SetActive(false);
    
}
