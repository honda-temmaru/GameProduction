using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者：桑原

public class ControllerOfDodge : MonoBehaviour
{
    [SerializeField] Dodge dodge;
    [SerializeField] InputAction cancelAction; //アクションを無効化する入力

    private void OnEnable()
    {
        cancelAction.Enable();
    }

    private void OnDisable()
    {
        cancelAction.Disable();
    }

    public void CallDodge(InputAction.CallbackContext context)
    {
        if (!context.performed || cancelAction.IsPressed()) return;

        dodge.TryDodge(); //回避処理の呼び出し
    }
}
