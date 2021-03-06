using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
    private Enemy1 enemy;
    public E1_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isDetectingLedge || isDetectingWall)
        {
            Debug.Log("Detecting Ledge = " + isDetectingLedge + " " + "Detecting Wall = " + isDetectingWall);
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }


        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
                stateMachine.ChangeState(enemy.playerDetectedState);
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
            
    }
}
