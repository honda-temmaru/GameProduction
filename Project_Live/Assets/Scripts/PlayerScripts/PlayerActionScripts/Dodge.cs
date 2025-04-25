using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class Dodge : MonoBehaviour
{
    [Header("1回ごとの回避時間")]
    [SerializeField] float dodgeDuration = 1f;
    [Header("回避状態解除後、次にできるようになるまでの時間")]
    [SerializeField] float dodgeInterval;
    [Header("回避による移動速度の加速量")]
    [SerializeField] float dodgeSpeed = 2.0f;

    float dodgeTimer = 0f; //回避状態に移行してからの経過時間計測用
    float intervalTimer = 0f; //回避状態解除後の経過時間計測用
    bool isDodging = false; //回避中かどうか

    public bool IsDodging {  get { return isDodging; } }

    void Update()
    {
        if (isDodging)
        {
            dodgeTimer += Time.deltaTime;

            if (dodgeTimer >= dodgeDuration)
            {
                isDodging = false;
                dodgeTimer = 0f;
                intervalTimer = 0f;
            }
        }

        else
        {
            if (intervalTimer < dodgeInterval)
                intervalTimer += Time.deltaTime;
        }
    }

    public void TryDodge() //回避処理
    {
        if (isDodging || intervalTimer < dodgeInterval) return;

        isDodging = true; //回避中
        dodgeTimer = 0f;
    }

    public float AddDodgeSpeed() //回避中の移動速度上昇量の取得
    {
        return isDodging ? dodgeSpeed : 0f;
    }
}
