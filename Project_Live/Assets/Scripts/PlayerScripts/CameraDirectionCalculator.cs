using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class CameraDirectionCalculator : MonoBehaviour
{
    Vector3 camForward;

    Vector3 camRight;

    public Vector3 CamForWard { get { return camForward; } }

    public Vector3 CamRight { get { return camRight; } }

    void Update()
    {
        GetCameraVectors();
    }

    private void GetCameraVectors() //カメラの各ベクトルの計算
    {
        camForward = Camera.main.transform.forward; //カメラの正面ベクトルを取得
        camRight = Camera.main.transform.right; //カメラの右方向ベクトルを取得

        //各ベクトルを水平面上の方向ベクトルにする
        camForward.y = 0;
        camRight.y = 0;

        //各ベクトルの正規化
        camForward.Normalize();
        camRight.Normalize();
    }
}
