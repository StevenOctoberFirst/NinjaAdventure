using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class FSM_Transitions
{
    public FSM_Decision Decision;
    public EnemyStateID TrueState;
    public EnemyStateID FalseState;
}
