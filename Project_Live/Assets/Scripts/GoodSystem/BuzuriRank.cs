using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BuzzRank
{
    [Header("�o�Y�������N��")]
    [SerializeField] string name;
    [Header("���̃o�Y�������N�ɕK�v�Ȃ����ː�")]
    [SerializeField] public float needNum;
    [Header("���̃o�Y�������N�̂����ˎ擾�{��")]
    [SerializeField] float goodMagnification;
    public float GoodMagnification => goodMagnification;
    [Header("���̃o�Y�������N�̃R�����g�̃X�|�[������")]
    [SerializeField] float commentSpawnTime;
    public float CommentSpawnTime => commentSpawnTime;    //�X�|�[�����ԎQ�Ɨp�Q�b�^�[
    [Header("���̃o�Y�������N�̐F")]
    [SerializeField] public Color rankColor;
}

public class BuzuriRank : MonoBehaviour
{
    [Header("�o�Y�������N�ݒ�")]
    [SerializeField] List<BuzzRank> buzzRanks;
    [Header("�o�Y�������N�Q�[�W�o�[")]
    [SerializeField] Slider BuzuriSlider;
    [Header("�K�v�ȃR���|�[�l���g")]
    [SerializeField] Image buzuriGage;

    private int currentIndex = 0;   //���݂̃N���X�̃C���f�b�N�X��
    private float beforeMaxValue = 0;   //�O�̃o�Y�������N�ɓ��B����܂łɕK�v�Ȃ����ː�

    [System.NonSerialized]
    public BuzzRank currentBuzzRank = new BuzzRank();   //���݂̃o�Y�������N���i�[���Ă����C���X�^���X

    GoodSystem goodSystem;

    // Start is called before the first frame update
    void Start()
    {
        goodSystem = this.GetComponent<GoodSystem>();
        currentBuzzRank = buzzRanks[currentIndex];  //�ŏ��̃o�Y�������N�����i�[
        buzuriGage.color = currentBuzzRank.rankColor;
        goodSystem.addGoodText.color=currentBuzzRank.rankColor;
        BuzuriSlider.maxValue = buzzRanks[currentIndex + 1].needNum;  //�o�Y�������N�Q�[�W�̍ő�l�����̃o�Y�������N�ɕK�v�Ȃ����ː��ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        BuzuriSlider.value = goodSystem.GoodNum - beforeMaxValue; //�����ː����猻�݂̃o�Y�������N�܂łɕK�v�����������ː�������

        if (currentIndex + 1 < buzzRanks.Count) //���̃o�Y�������N���ݒ肳��Ă���Ύ��s
        {
            if (goodSystem.GoodNum >= buzzRanks[currentIndex + 1].needNum)  //�����ː������̃o�Y�������N�ɕK�v�Ȑ��ɓ��B��������s
            {
                currentIndex++; //���̃C���f�b�N�X���Ɉړ�
                currentBuzzRank = buzzRanks[currentIndex];  //�o�Y�������N���グ��
                buzuriGage.color = currentBuzzRank.rankColor;    
                goodSystem.addGoodText.color = currentBuzzRank.rankColor;   //�o�Y�������N�Q�[�W�Ƃ����ˊl���������݂̃o�Y�������N�̐F�ɂ���
                if (currentIndex + 1 != buzzRanks.Count)    //�ݒ肳��Ă���ō��̃o�Y�������N�ɓ��B���Ă��邩�m�F
                {
                    BuzuriSlider.maxValue = currentBuzzRank.needNum - buzzRanks[currentIndex - 1].needNum;    //�Q�[�W�����Z�b�g�����邽�߂̏���
                    beforeMaxValue = currentBuzzRank.needNum;   //���݂̃o�Y�������N�܂łɕK�v�����������ː����
                }
                Debug.Log("�����ː���" + currentBuzzRank.needNum + "�𒴂����̂Ńo�Y�������N�������A�����ˎ擾�{����" + currentBuzzRank.GoodMagnification + "�A�R�����g�̃X�|�[�����Ԃ�" + currentBuzzRank.CommentSpawnTime + "�b�ɕύX���܂����B");
            }
        }
    }
}
