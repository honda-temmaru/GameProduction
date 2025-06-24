using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬�ҁF�K��

public class GoodPointDisplay : MonoBehaviour
{
    [Header("�����˃A�N�V����1�Ɏg�p����|�C���g�~�ϗʕ\���p�e�L�X�g")]
    [SerializeField] TextMeshProUGUI goodPointText1;
    [Header("�����˃A�N�V����2�Ɏg�p����|�C���g�~�ϗʕ\���p�e�L�X�g")]
    [SerializeField] TextMeshProUGUI goodPointText2;
    [Header("�����˃A�N�V����3�Ɏg�p����|�C���g�~�ϗʕ\���p�e�L�X�g")]
    [SerializeField] TextMeshProUGUI goodPointText3;
    [Header("�����˃A�N�V����4�Ɏg�p����|�C���g�~�ϗʕ\���p�e�L�X�g")]
    [SerializeField] TextMeshProUGUI goodPointText4;

    [Header("�ʏ펞�̃e�L�X�g�̐F")]
    [SerializeField] Color normalColor = Color.blue;
    [Header("�����˃A�N�V���������\���̃e�L�X�g�̐F")]
    [SerializeField] Color highlightColor = Color.red;

    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] GoodAction goodAction;
    [SerializeField] GoodPointNotifier notifier;

    void Start()
    {
        if (notifier != null)
            notifier.OnGoodPointChanged += HandleGoodPointChanged;

        RefreshAll(); //�����\��
    }

    void OnDestroy()
    {
        if (notifier == null) return;

        notifier.OnGoodPointChanged -= HandleGoodPointChanged;
    }

    void HandleGoodPointChanged(int index, int current) //�󂯎�����ʒm�̏������ƂɊe�\�����X�V����
    {
        switch (index)
        {
            case 1:
                UpdateDisplay(goodPointText1, current, goodAction.GoodCost1, 1);
                break;
            
            case 2:
                UpdateDisplay(goodPointText2, current, goodAction.GoodCost2, 2);
                break;
            
            case 3:
                UpdateDisplay(goodPointText3, current, goodAction.GoodCost3, 3);
                break;
            
            case 4:
                UpdateDisplay(goodPointText4, current, goodAction.GoodCost4, 4);
                break;

            default: break;
        }
    }

    void UpdateDisplay(TextMeshProUGUI textObj, int currentPoint, int cost, int index) //�\���̍X�V
    {
        textObj.text = "GP" + index + ":"+ currentPoint;
        textObj.color = (currentPoint >= cost) ? highlightColor : normalColor;
    }

    void RefreshAll() //�\���̏����ݒ�
    {
        HandleGoodPointChanged(1, goodAction.CurrentGoodPoint1);
        HandleGoodPointChanged(2, goodAction.CurrentGoodPoint2);
        HandleGoodPointChanged(3, goodAction.CurrentGoodPoint3);
        HandleGoodPointChanged(4, goodAction.CurrentGoodPoint4);
    }
}
