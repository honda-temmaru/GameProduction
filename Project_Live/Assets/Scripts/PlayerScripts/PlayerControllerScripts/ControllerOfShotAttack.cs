using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬�ҁF�K��

public class ControllerOfShotAttack : MonoBehaviour
{
    [SerializeField] ShotAttack shotAttack;
    [SerializeField] InputAction cancelAction; //�A�N�V�����𖳌����������

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
