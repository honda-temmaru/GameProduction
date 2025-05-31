using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerStateManager;

//çÏê¨é“ÅFåKå¥

public class PlayerStateManager : MonoBehaviour
{
    public enum State
    {
        Idle, Attack, Shot, Dodge, GoodAction1, GoodAction2, GoodAction3, GoodAction4
    };

    State currentState;

    private void Start()
    {
        currentState = State.Idle;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                return;

            case State.Attack:
                return;

            case State.Shot:
                return;

            case State.Dodge:
                return;

            case State.GoodAction1: return;

            case State.GoodAction2: return;

            case State.GoodAction3: return;

            case State.GoodAction4: return;

            default: return;
        }
    }
}
