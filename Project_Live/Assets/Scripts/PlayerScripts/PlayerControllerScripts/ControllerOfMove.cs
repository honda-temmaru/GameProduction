using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬�F�K��

public class ControllerOfMove : MonoBehaviour
{
    [SerializeField] MovePlayer movePlayer;

    Vector3 currentMoveVec = Vector3.zero;
    bool isMovingInput = false;

    void Update()
    {
        if (isMovingInput && currentMoveVec != Vector3.zero)
        {
            movePlayer.GetMoveVector(currentMoveVec);
            PlayerActionEvents.MoveEvent();
        }
    }

    public void GetInputVector(InputAction.CallbackContext context)
    {
        Vector2 getVec = context.ReadValue<Vector2>(); //���͕������擾����
        currentMoveVec = new Vector3(getVec.x, 0, getVec.y);
        isMovingInput = getVec != Vector2.zero;

        if (isMovingInput) return;

        movePlayer.GetMoveVector(currentMoveVec); //�v���C���[�̈ړ��X�N���v�g�ɒl��n��

        PlayerActionEvents.MoveEvent(); //���͂̒ʒm
    }

    public void OnMoveCanceled(InputAction.CallbackContext context)
    {
        currentMoveVec = Vector3.zero;
        isMovingInput = false;
        movePlayer.GetMoveVector(Vector3.zero);
    }
}
