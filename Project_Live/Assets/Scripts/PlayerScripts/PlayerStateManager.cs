using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStateManager;

//作成者：桑原

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField]
    public struct StateFlags
    {
        public bool isInvincible;
    }

    [Header("マテリアルの変更を行うオブジェクト")]
    [SerializeField] Renderer playerRenderer;

    [Header("通常時用のマテリアル")]
    [SerializeField] Material normalMaterial;
    [Header("無敵状態時用のマテリアル")]
    [SerializeField] Material invincibleMaterial;

    [Header("必要なコンポーネント")]
    [SerializeField] Dodge dodge;

    StateFlags currentStateFlags;
    StateFlags previousStateFlags;

    Renderer targetRenderer;

    void Start()
    {
        targetRenderer = playerRenderer.GetComponent<Renderer>();
    }

    void Update()
    {
        currentStateFlags.isInvincible = dodge.IsDodging; //現在の回避状態を更新

        CheckAndLogStateChange();

        UpdateMaterialOnState();
    }

    private void CheckAndLogStateChange() //状態変化に応じた処理
    {
        if (currentStateFlags.isInvincible != previousStateFlags.isInvincible)
        {
            if (currentStateFlags.isInvincible)
                Debug.Log("無敵です！");
        }

        previousStateFlags = currentStateFlags;
    }

    private void UpdateMaterialOnState() //状態によってマテリアルを変更する処理
    {
        if (currentStateFlags.isInvincible)
        {
            targetRenderer.material = invincibleMaterial;
        }

        else
            targetRenderer.material = normalMaterial;
    }
}
