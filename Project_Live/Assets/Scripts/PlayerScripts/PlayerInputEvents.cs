using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//イベントの定義
public static class PlayerInputEvents
{
    public static event System.Action OnIdleInput;
    public static event System.Action OnMoveInput;
    public static event System.Action OnCloseAttackInput;
    public static event System.Action OnShotInput;
    public static event System.Action OnDodgeInput;
    public static event System.Action OnGoodAction1Input;
    public static event System.Action OnGoodAction2Input;
    public static event System.Action OnGoodAction3Input;
    public static event System.Action OnGoodAction4Input;

    public static void IdleInput()
    {
        OnIdleInput?.Invoke();
    }

    public static void MoveInput()
    {
        OnMoveInput?.Invoke();
    }

    public static void CloseAttackInput()
    {
        OnCloseAttackInput?.Invoke();
    }

    public static void ShotInput() 
    {
        OnShotInput?.Invoke();
    }

    public static void DodgeInput()
    {
        OnDodgeInput?.Invoke();
    }

    public static void GoodAction1Input()
    {
        OnGoodAction1Input?.Invoke();
    }

    public static void GoodAction2Input()
    {
        OnGoodAction2Input?.Invoke();
    }

    public static void GoodAction3Input()
    {
        OnGoodAction3Input?.Invoke();
    }

    public static void GoodAction4Input()
    {
        OnGoodAction4Input?.Invoke();
    }
}
