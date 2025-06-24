using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬�ҁF�K��

public class BeamMover : MonoBehaviour
{
    [Header("�r�[�����L�т鑬��")]
    [SerializeField] float speed = 10f;
    [Header("�r�[�����L�т�ő�̒���")]
    [SerializeField] float maxLength = 10f;
    [Header("�`���ς���I�u�W�F�N�g")]
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
