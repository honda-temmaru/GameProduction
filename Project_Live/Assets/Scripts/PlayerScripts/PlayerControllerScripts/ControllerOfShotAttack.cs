using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者：桑原

public class ControllerOfShotAttack : MonoBehaviour
{
    [SerializeField] ShotAttack shotAttack;
    [SerializeField] InputAction cancelAction; //アクションを無効化する入力

    private void OnEnable()
    {
        cancelAction.Enable();
    }

    private void OnDisable()
    {
        cancelAction.Disable();
    }

    public void CallShotAttack(InputAction.CallbackContext context)
    {
        if (!context.performed || cancelAction.IsPressed()) return;

        PlayerActionEvents.ShotEvent();
        shotAttack.TryShot();
    }
}
