//�쐬��:����

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentGet : MonoBehaviour
{
    [Header("�����˂̍ŏ��擾�l")]
    [SerializeField] int minNum = 5;
    [Header("�����˂̍ő�擾�l")]
    [SerializeField] int maxNum = 10;

    GoodSystem goodSystem;
    bool getTrigger = false;    //2�d���h���p�̃t���O

    // Start is called before the first frame update
    void Start()
    {
        goodSystem = GameObject.FindWithTag("GoodSystem").GetComponent<GoodSystem>();    //�X�N���v�gGoodSystem�̕ϐ����������߂̂��܂��Ȃ�
    }

    int DesideGoodNumValue(int minNum, int maxNum)
    {
        int value = Random.Range(minNum, maxNum);
        Debug.Log("�R�����g���擾���A�����˂�" + value + "�l�����܂����B");
        return value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (getTrigger)
            return;
        if (other.gameObject.CompareTag("Player"))  //Player�Ɏ��ꂽ��s���鏈��  
        {
            getTrigger = true;
            Destroy(this.gameObject);
            goodSystem.AddGood(DesideGoodNumValue(minNum, maxNum));
        }
    }
}
