using UnityEngine;

public abstract class BaseState : State
{

    public virtual void OnEnter()
    {
        // throw new System.NotImplementedException();

    }

    public State OnUpdate()
    {
        return this;
    }
}