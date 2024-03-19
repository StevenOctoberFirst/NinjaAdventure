using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateID
{
    NONE, WANDER, PATROL, CHASE, ATTACK
}

[System.Serializable]
public class FSM_State
{
    public EnemyStateID EnemyStateID;
    public FSM_Action[] Actions;
    public FSM_Transitions[] Transitions;

    public void ExecuteActions()
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].Act();
        }
    }

    public void UpdateState(EnemyBrain brain)
    {
        ExecuteActions();
        ExecuteTransitions(brain);
    }

    public void ExecuteTransitions(EnemyBrain brain)
    {
        if (Transitions == null || Transitions.Length <= 0)
            return;

        for(int i = 0;i < Transitions.Length;)
        {
            var value = Transitions[i].Decision.Decide();

            if (value)
            {
                brain.ChangeState(Transitions[i].TrueState);
            }
            else
            {
                brain.ChangeState(Transitions[i].FalseState);
            }
        }

    }
}
