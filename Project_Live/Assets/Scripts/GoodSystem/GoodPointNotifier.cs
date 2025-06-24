using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPointNotifier : MonoBehaviour
{
    [SerializeField] GoodAction goodAction;

    public event System.Action<int, int> OnGoodPointChanged;

    int[] prevPoints = new int[4];

    void Update()
    {
        CheckAndNotify(1, goodAction.CurrentGoodPoint1);
        CheckAndNotify(2, goodAction.CurrentGoodPoint2);
        CheckAndNotify(3, goodAction.CurrentGoodPoint3);
        CheckAndNotify(4, goodAction.CurrentGoodPoint4);
    }

    void CheckAndNotify(int index, int current) //�e�����˃|�C���g�̒~�ϗʂɕω�����������m�点��
    {
        if (prevPoints[index - 1] == current) return; //�ω����Ȃ������牽�����Ȃ�
        
        OnGoodPointChanged?.Invoke(index, current); //�C�x���g�̔��΂Ɠ����ɁA�ʒm��ɔԍ��ƑΉ����邢���˃|�C���g����n��
        prevPoints[index - 1] = current;
    }
}
