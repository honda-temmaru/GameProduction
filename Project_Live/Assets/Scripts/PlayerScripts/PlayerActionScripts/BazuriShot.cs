using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//作成者:福島
public class BazuriShot : MonoBehaviour// バズリショットモードの切り替えの管理
{
    [SerializeField] PlayerInput playerInput;
    [Header("メインのカメラ")]
    [SerializeField] GameObject mainCamera;
    [Header("バズリショットの際に操作するカメラ")]
    [SerializeField] GameObject bazuriCamera;
    public GameObject BazuriCamera
    {
        get
        {   return bazuriCamera;
        }
        set
        {    bazuriCamera = value;
        }
    }
    [Header("カメラの操作時間")]
    [SerializeField] float cameraTime;
    [Header("スロー時のゲーム速度(1未満じゃないとスローにならない)")]
    [SerializeField] float slowSpeed;

    [SerializeField] Transform defaultPos;
    private bool isBazuri = false;
    public bool IsBazuri
    {
        get { return isBazuri; }
    }
    private float  count;
    
    private void Start()
    {
        bazuriCamera.SetActive(false);
        defaultPos=bazuriCamera.transform;
    }

    private void Update()
    {
        if (isBazuri)
        {
            count += Time.unscaledDeltaTime;
            if (count >= cameraTime)
            {
                isBazuri = false;
                mainCamera.SetActive(true);
                bazuriCamera.SetActive(false);
                Time.timeScale = 1;
                playerInput.SwitchCurrentActionMap("Player");
                bazuriCamera.transform.position = defaultPos.position;
                count = 0;

            }
        }
    }
    public void TryBazuriShot()
    {
        if (isBazuri) return;
        Debug.Log("バズりショット発動！");
        isBazuri = true;
        mainCamera.SetActive(false);
        bazuriCamera.SetActive(true);
        Time.timeScale = slowSpeed;
        playerInput.SwitchCurrentActionMap("Bazuri");

    }
}
