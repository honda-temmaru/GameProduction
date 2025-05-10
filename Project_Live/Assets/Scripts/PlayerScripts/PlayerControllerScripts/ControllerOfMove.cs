using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成：桑原

public class ControllerOfMove : MonoBehaviour
{
    [SerializeField] MovePlayer movePlayer;

    //public event System.Action OnCloseMovePerformed;

    public void GetInputVector(InputAction.CallbackContext context)
    {
        Vector2 getVec = context.ReadValue<Vector2>(); //入力方向を取得する
        Vector3 moveVec = new Vector3(getVec.x, 0, getVec.y);
        movePlayer.GetMoveVector(moveVec); //プレイヤーの移動スクリプトに値を渡す

        //OnCloseMovePerformed?.Invoke(); //処理が呼ばれたことを通知する
    }
}
