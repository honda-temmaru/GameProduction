using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：桑原

public class BeamMover : MonoBehaviour
{
    [Header("ビームが伸びる速さ")]
    [SerializeField] float speed = 10f;
    [Header("ビームが伸びる最大の長さ")]
    [SerializeField] float maxLength = 10f;
    [Header("形状を変えるオブジェクト")]
    [SerializeField] Transform target;

    float currentLength = 0f;
    float previewLength = 0f;
    Vector3 initialScale;

    void Start()
    {
        if (target == null) return;

        initialScale = target.localScale;
        previewLength = initialScale.y;
    }


    void Update()
    {
        if (currentLength > maxLength) return;

        previewLength = initialScale.y;

        currentLength += speed * Time.deltaTime;
        //currentLength = Mathf.Min(currentLength, maxLength);

        target.localScale = new Vector3(initialScale.x, currentLength, initialScale.z);

        float delta = currentLength - previewLength;

        target.localPosition = new Vector3(0, 0, (currentLength + delta) / 2);
    }
}
