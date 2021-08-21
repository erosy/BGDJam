using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingPlayerState : State
{
    protected D_DetectingPlayerState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;
    protected bool performLongRangeAction;
    public DetectingPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DetectingPlayerState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0);
        performLongRangeAction = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Time.time >= startTime + stateData.actionTime)
            performLongRangeAction = true;
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
    }
}
