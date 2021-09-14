using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

//[RequireComponent(typeof(PlayerInput))]
public class PlayerInputHandler : MonoBehaviour
{
  //  private PlayerInput input;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
       // input = GetComponent<PlayerInput>();
        player = GetComponent<Player>();
    }

    public void OnMove(CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            if (!player.cannotMove)
                player.inputDirection = ctx.ReadValue<Vector2>();
            else
                player.inputDirection.x = 0;
        }
    }

    public void OnJump(CallbackContext ctx)
    {
        if (!player.cannotMove)
        {
            if (ctx.phase == InputActionPhase.Performed)
                player.jumpPressed = true;
            if (ctx.phase == InputActionPhase.Canceled)
                player.JumpKeyUp();
        }
       
    }


    public void OnTeleport(CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            if (!player.cannotMove)
                player.Teleport();
        }
           
    }

    public void OnInteract(CallbackContext ctx)
    {
      
            if (ctx.phase == InputActionPhase.Performed)
        {
            if (!player.cannotMove)
                player.InteractObject();
        }
           
    }
  
    public void OnPause(CallbackContext ctx)
    {
        if(ctx.phase == InputActionPhase.Performed)
        {
            GameManager.instance.PausePanel();
        }
    }
}
