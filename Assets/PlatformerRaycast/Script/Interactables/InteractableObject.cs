using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    protected GameObject player;
    protected Player playerScript;
    public UnityEvent onInteract;
    public UnityEvent onUninteract;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        playerScript = player.GetComponent<Player>();
    }

    public virtual void Interact() => onInteract.Invoke();
    public virtual void UnInteract() => onUninteract.Invoke();

    protected void OnTriggerEnter2D(Collider2D collision) => OnCollideInteractableObject(collision);

    protected void OnTriggerExit2D(Collider2D collision) => OnLeavingInteractableObject(collision);

    public virtual void OnCollideInteractableObject(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript.interactableObject = this.gameObject;
            playerScript.isInteractable = true;
        }
    }

    public virtual void OnLeavingInteractableObject(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript.interactableObject = null;
            playerScript.isInteractable = false;
        }
    }
}
