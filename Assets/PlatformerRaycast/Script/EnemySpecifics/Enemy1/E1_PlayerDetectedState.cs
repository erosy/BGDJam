using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_PlayerDetectedState : DetectingPlayerState
{
    private Enemy1 enemy;

    public E1_PlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DetectingPlayerState stateData, Enemy1 enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void LogicUpdate()
    {
       
        base.LogicUpdate();
        if (performLongRangeAction)
        {
            
            //enemy.idleState.SetFlipAfterIdle(false);
            //else
                stateMachine.ChangeState(enemy.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
            stateMachine.ChangeState(enemy.lookForPlayerState);

    }


}
