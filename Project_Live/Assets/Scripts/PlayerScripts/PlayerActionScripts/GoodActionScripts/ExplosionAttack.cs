using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class ExplosionAttack : MonoBehaviour
{
    [Header("��������I�u�W�F�N�g")]
    [SerializeField] GameObject explosionPrefab;
    [Header("�������锚���̐�")]
    [SerializeField] int explosionCount = 5;
    [Header("�����̐����Ԋu")]
    [SerializeField] float explosionIntervalTime = 0.2f;

    [Header("�����̐����͈�")]
    [SerializeField] BoxCollider spawnRange;
    [Header("�����̒��S��n�ʂɐڒn�����邩")]
    [SerializeField] bool setToGround = true;

    float currentIntervalTime = 0f;
    int currentExplosionCount = 0;
    bool isStartProcess = false;

    void Update()
    {
        if (!isStartProcess) return;

        currentIntervalTime += Time.deltaTime;

        SpawnExplosions();
    }
    public void TriggerExplosions() //�������J�n����
    {
        isStartProcess = true; //�����������J�n����
    }

    void SpawnExplosions() //�����̐���
    {
        if (currentIntervalTime < explosionIntervalTime) return;

        if (currentExplosionCount >= explosionCount) //��������萔�������ꂽ�ꍇ
        {
            currentExplosionCount = 0;
            isStartProcess = false; //�����������������s���Ȃ��悤�ɂ���
            return;
        }

        Vector3 randomPos;

        randomPos = GetRandomPositionInsideCollider(); //�����_���Ȉʒu���擾����

        Instantiate(explosionPrefab, randomPos, Quaternion.identity);
        currentIntervalTime = 0f; //�o�ߎ��Ԃ����Z�b�g����
        currentExplosionCount++; //�����̃J�E���g���𑝂₷
    }

    Vector3 GetRandomPositionInsideCollider() //�����ʒu�̎擾
    {
        Vector3 center = spawnRange.center + spawnRange.transform.position;
        Vector3 size = Vector3.Scale(spawnRange.size, spawnRange.transform.lossyScale);

        float x = Random.Range(-size.x / 2, size.x / 2);
        float z = Random.Range(-size.z / 2, size.z / 2);
        float y = setToGround ? spawnRange.center.y : Random.Range(-size.y / 2, size.y / 2);

        return center + new Vector3(x, y, z);
    }
}
