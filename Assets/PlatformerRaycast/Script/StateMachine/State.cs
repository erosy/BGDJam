using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    //class isinya konfigurasi state secara dasar (state masuk, exit, update), diturunkan untuk state state yang ingin dibuat
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
    protected float startTime;
    protected string animBoolName;
    public State(Entity entity, FiniteStateMachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animBoolName, true);
        CheckConditions();
    }
    public virtual void Exit()
    {
        entity.anim.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {
        CheckConditions();
    }

    public virtual void CheckConditions()
    {

    }
}
