//�쐬�ҁ@����

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoodSystem : MonoBehaviour
{
    [Header("�����ː��̃e�L�X�g")]
    [SerializeField] TextMeshProUGUI goodText;

    [Header("�����ˊl�����̃e�L�X�g")]
    public TextMeshProUGUI addGoodText;

    [Header("���Z�܂ł̑ҋ@����")]
    [SerializeField] float getDuration;

    private int goodNum;    //�����ː�
    public float GoodNum => goodNum; //�����ː��̃Q�b�^�[

    private float addGoodNum;   //�ŏI�l�������ˎ擾��
    public float AddGoodNum => addGoodNum;  //�ŏI�l�������ː��̃Q�b�^�[

    private bool isTracking = false;    //�l���ҋ@�����m�F�p�t���O

    BuzuriRank buzuriRank;

    // Start is called before the first frame update
    void Start()
    {
        buzuriRank = this.GetComponent<BuzuriRank>();
        goodNum = 0;    //�J�n���̓[��
        addGoodText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        goodText.text = goodNum.ToString();     //�����ː���string�ɕϊ����ĉ�ʂɕ\��
        Debug.Log("�����ː�:" + goodNum);
    }

    public void AddGood(float value)    //���̃N���X����Ă΂�邢���ˉ��Z�̂��߂̊֐�
    {
        addGoodNum += value;
        addGoodText.text = addGoodNum.ToString() + "�~" + buzuriRank.currentBuzzRank.GoodMagnification.ToString();
        if (!isTracking) //���ݎ擾���Ԓ����m�F
        {
            StartCoroutine(TrackAndApplyGoodNum());
        }
    }

    private IEnumerator TrackAndApplyGoodNum()  //�ŏI�l�������ː����擾���A���݂̂����ː��ɉ��Z����֐�
    {
        isTracking = true;

        addGoodText.enabled = true;

        yield return new WaitForSeconds(getDuration);   //��莞�Ԃ��̊֐��̏������~�߂�R���[�`��

        addGoodNum *= buzuriRank.currentBuzzRank.GoodMagnification; //�ŏI�l�������ː��Ɍ��݂̃o�Y�������N�̂����ˎ擾�{����������

        addGoodText.enabled = false;

        goodNum += (int)addGoodNum; //���݂̂����ː��ɍŏI�l�������ː������Z

        addGoodNum = 0; //�ŏI�l�������ː������Z�b�g

        isTracking = false;
    }
}