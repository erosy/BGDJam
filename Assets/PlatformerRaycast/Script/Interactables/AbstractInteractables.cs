using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class AbstractInteractables : MonoBehaviour
{
    public abstract void Interactables();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().isInteractable = true;
            collision.GetComponent<Player>().interactableObject = this.gameObject;

        }
            

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().isInteractable = false;
            collision.GetComponent<Player>().interactableObject = null;
        }
            
    }
}
