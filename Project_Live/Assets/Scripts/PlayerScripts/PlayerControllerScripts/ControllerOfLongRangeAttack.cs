using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者：桑原

public class ControllerOfLongRangeAttack : MonoBehaviour
{
    [SerializeField] LongRangeAttack longRangeAttack;
    [SerializeField] InputAction cancelAction; //アクションを無効化する入力

    private void OnEnable()
    {
        cancelAction.Enable();
    }

    private void OnDisable()
    {
        cancelAction.Disable();
    }

    public void CallLongRangeAttack(InputAction.CallbackContext context)
    {
        if (!context.performed || cancelAction.IsPressed()) return;

        longRangeAttack.ShotBullet();
    }
}
