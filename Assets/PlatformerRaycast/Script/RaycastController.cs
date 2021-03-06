using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour
{
    protected const float skinWidth = .015f;
    protected const float distanceBetweenRays = .1f;
    protected int horizontalRayCount;
    protected int verticalRayCount;

    protected float horizontalRaySpacing;
    protected float verticalRaySpacing;

    protected BoxCollider2D boxCollider2D;
    protected RaycastOrigins raycastOrigins;

    public virtual void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        CalculateRaySpacing();
    }
    protected void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider2D.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider2D.bounds;
        bounds.Expand(skinWidth * -2);

        float boundsWidth = bounds.size.x;
        float boundsHeight = bounds.size.y;

        horizontalRayCount = Mathf.RoundToInt(boundsHeight/distanceBetweenRays);
        verticalRayCount = Mathf.RoundToInt(boundsWidth/distanceBetweenRays);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }
    protected struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }

}
