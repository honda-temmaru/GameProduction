using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬�ҁF�K��

public class ControllerOfDodge : MonoBehaviour
{
    [SerializeField] Dodge dodge;
    [SerializeField] InputAction cancelAction; //�A�N�V�����𖳌����������

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

        PlayerActionEvents.DodgeEvent(); //�����͂̒ʒm
    }
}
