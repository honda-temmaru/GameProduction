using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬�ҁF�K��

public class ControllerOfGoodAction : MonoBehaviour
{
    [SerializeField] GoodAction goodAction;

    public void CallGoodAction1(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        PlayerActionEvents.GoodAction1Event(); //�C�C�l�A�N�V����1�̌Ăяo��
    }

    public void CallGoodAction2(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        PlayerActionEvents.GoodAction2Event(); //�C�C�l�A�N�V����2�̌Ăяo��
    }

    public void CallGoodAction3(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        PlayerActionEvents.GoodAction3Event(); //�C�C�l�A�N�V����3�̌Ăяo��
    }

    public void CallGoodAction4(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        PlayerActionEvents.GoodAction4Event(); //�C�C�l�A�N�V����4�̌Ăяo��
    }
}
