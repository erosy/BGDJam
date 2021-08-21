using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{
    protected D_LookForPlayerState stateData;
    protected bool turnImmidiately;
    protected bool isPlayerInMinAgroRange;
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;
    protected float lastTurnTime;
    protected int amountOfTurnsDone;

    public LookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayerState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;
        lastTurnTime = startTime;
        amountOfTurnsDone = 0;
        entity.SetVelocity(0);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (turnImmidiately)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            turnImmidiately = false;
        }
        else if (Time.time > lastTurnTime + stateData.timeBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone ++;
        }

        if (amountOfTurnsDone >= stateData.turnAmount)
            isAllTurnsDone = true;
        if (Time.time >= lastTurnTime + stateData.timeBetweenTurns && isAllTurnsDone)
            isAllTurnsTimeDone = true;
            
           
    }

    public override void CheckConditions()
    {
        base.CheckConditions();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

    public void SetTurnImmidiately(bool flip)
    {
        turnImmidiately = flip;
    }
}
