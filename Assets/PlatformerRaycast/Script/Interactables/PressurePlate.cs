using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : InteractableObject
{
    public bool isInteracting;

    public override void OnCollideInteractableObject(Collider2D collision)
    {
        if (!isInteracting)
        {
            base.Interact();
            isInteracting = true;

        }
    }

    public override void OnLeavingInteractableObject(Collider2D collision) => UnInteract();

    public override void UnInteract()
    {
        onUninteract.Invoke();
        Invoke(nameof(ResetPressurePlateInteraction), 1f);
     
    }

    public void ExampleInteract() => Debug.Log("Pressure Plated is stomped");
    public void ExampleUninteract() => Debug.Log("Pressure Plated is not stomped");
    public void ResetPressurePlateInteraction() => isInteracting = false;
}
