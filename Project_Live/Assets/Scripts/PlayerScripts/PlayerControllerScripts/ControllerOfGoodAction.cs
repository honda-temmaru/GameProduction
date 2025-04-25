using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者：桑原

public class ControllerOfGoodAction : MonoBehaviour
{
    [SerializeField] GoodAction goodAction;

    public void CallGoodAction1(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        goodAction.GoodAction1(); //イイネアクション1の呼び出し
    }

    public void CallGoodAction2(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        goodAction.GoodAction2(); //イイネアクション2の呼び出し
    }

    public void CallGoodAction3(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        goodAction.GoodAction3(); //イイネアクション3の呼び出し
    }

    public void CallGoodAction4(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        goodAction.GoodAction4(); //イイネアクション4の呼び出し
    }
}
