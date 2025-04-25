using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者：桑原

public class ControllerOfCloseAttack : MonoBehaviour
{
    [SerializeField] CloseAttack closeAttack;
    [SerializeField] InputAction cancelAction; //アクションを無効化する入力

    private void OnEnable()
    {
        cancelAction.Enable();
    }

    private void OnDisable()
    {
        cancelAction.Disable();
    }

    public void CallCloseAttack(InputAction.CallbackContext context)
    {
        if (!context.performed || cancelAction.IsPressed()) return;

        closeAttack.TryAttack(); //近接攻撃処理の呼び出し
    }
}
