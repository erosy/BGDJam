using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : AbstractInteractables
{
    public override void Interactables()
    {
        FindObjectOfType<Player>().portalTransform = this.transform;
        Debug.Log("PORTAL ACTIVATED");
    }
}
