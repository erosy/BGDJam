using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : AbstractInteractables
{
    private PlayAudio playAudio;

    private void Start()
    {
        playAudio = GetComponent<PlayAudio>();
    }
    public override void Interactables()
    {
        FindObjectOfType<Player>().portalTransform = this.transform;
        Debug.Log("PORTAL ACTIVATED");
        playAudio.PlaySimpleAudio();
    }
}
