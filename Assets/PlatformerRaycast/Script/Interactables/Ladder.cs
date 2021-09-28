using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ladder : InteractableObject
{

    public override void OnLeavingInteractableObject(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript.interactableObject = null;
            playerScript.isInteractable = false;

            if (playerScript.isClimbing)
                UnInteract();
        }

    }
    public void PlayerClimbing()
    {
        player.transform.position = new Vector2(this.transform.position.x, player.transform.position.y);
        playerScript.interactableObject = this.gameObject;
        playerScript.isInteractable = true;
        playerScript.isClimbing = true;
    }

    public void ResetPlayerClimbing()
    {
        playerScript.isClimbing = false;
    }
   
}
