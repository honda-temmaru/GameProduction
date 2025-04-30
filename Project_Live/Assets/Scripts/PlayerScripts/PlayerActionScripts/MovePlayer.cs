using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class MovePlayer : MonoBehaviour
{
    [Header("動かすオブジェクト")]
    [SerializeField] Transform target;
    [Header("移動スピード")]
    [SerializeField] float speed = 10f;
    [Header("回転スピード")]
    [SerializeField] float rotationSpeed = 10f;

    [Header("必要なコンポーネント")]
    
    [SerializeField] CameraDirectionCalculator cameraDirectionCalculator;
    [SerializeField] Dodge dodge;

    Vector3 move; //入力値取得用変数
    Vector3 prev_Move = Vector3.zero; //前フレームの移動値保存用変数

    Vector3 moveDirection; //移動方向用の変数

    public Vector3 Move { get { return move; } }
    public Vector3 Prev_Move { get {  return prev_Move; } }

    void Update()
    {
        if (move.magnitude > 0.1f) //移動の入力があったら
        {
            CalculateMoveDirection();
            RotateTransform();
            MoveTransform();           
        }

        prev_Move = move; //移動の値を保存
    }

    void CalculateMoveDirection() //移動方向の計算
    {
        moveDirection = cameraDirectionCalculator.CamForWard * move.z + cameraDirectionCalculator.CamRight * move.x; //移動方向の算出
    }

    void MoveTransform() //移動処理
    {    
        target.transform.position += moveDirection * (speed + dodge.AddDodgeSpeed()) * Time.deltaTime;
    }

    void RotateTransform() //回転処理
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

        //回転速度に制限をかける
        target.transform.rotation = Quaternion.RotateTowards(target.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void GetMoveVector(Vector3 getVec)
    {
        move = new Vector3(getVec.x, 0, getVec.z); //入力値の取得
    }
}
