using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

//�C�x���g�̒�`
public static class PlayerActionEvents
{
    public static event System.Action OnIdleEvent;
    public static event System.Action OnMoveEvent;
    public static event System.Action OnCloseAttackEvent;
    public static event System.Action OnShotEvent;
    public static event System.Action OnDodgeEvent;
    public static event System.Action OnGoodAction1Event;
    public static event System.Action OnGoodAction2Event;
    public static event System.Action OnGoodAction3Event;
    public static event System.Action OnGoodAction4Event;

    public static void IdleEvent()
    {
        OnIdleEvent?.Invoke();
    }

    public static void MoveEvent()
    {
        OnMoveEvent?.Invoke();
    }

    public static void CloseAttackEvent()
    {
        OnCloseAttackEvent?.Invoke();
    }

    public static void ShotEvent() 
    {
        OnShotEvent?.Invoke();
    }

    public static void DodgeEvent()
    {
        OnDodgeEvent?.Invoke();
    }

    public static void GoodAction1Event()
    {
        OnGoodAction1Event?.Invoke();
    }

    public static void GoodAction2Event()
    {
        OnGoodAction2Event?.Invoke();
    }

    public static void GoodAction3Event()
    {
        OnGoodAction3Event?.Invoke();
    }

    public static void GoodAction4Event()
    {
        OnGoodAction4Event?.Invoke();
    }
}
