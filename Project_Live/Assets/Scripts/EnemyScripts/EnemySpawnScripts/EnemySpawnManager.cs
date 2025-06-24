using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnParameter
{
    [Header("��������G�v���n�u")]
    public GameObject enemyPrefab;
    [Header("���̓G�̍ő哯���o����")]
    public int maxSpawnCount;
    [Header("���̓G�̎��")]
    public EnemyType enemyType;
}

public class EnemySpawnManager : MonoBehaviour
{
    [Header("�X�|�[��������I�u�W�F�N�g�̐ݒ�")]
    [SerializeField] List<SpawnParameter> spawnParameters;
    [Header("�����͈�")]
    [SerializeField] BoxCollider spawnArea;
    [Header("�G�̐��̃`�F�b�N�Ԋu")]
    [SerializeField] float checkInterval = 1.0f;

    Dictionary<EnemyType, EnemySpawn> spawners = new();
    Dictionary<EnemyType, EnemyCountTracker> trackers = new();

    float timer = 0f;
    void Start()
    {
        foreach (var param in spawnParameters) //�ݒ肳�ꂽ�G�̎�ނ̐������������J��Ԃ�
        {
            spawners[param.enemyType] = new EnemySpawn(param.enemyPrefab, spawnArea);
            trackers[param.enemyType] = new EnemyCountTracker(param.enemyType);
            spawners[param.enemyType].SpawnEnemies(param.maxSpawnCount); //�G�̏�������
        }
    }
    void Update()
    {
        timer += Time.deltaTime;

        foreach (var param in spawnParameters)
        {
            var tracker = trackers[param.enemyType];

            if (timer >= checkInterval && tracker.HasChanged(out int currentCount)) //���ׂ���ނ̓G�̐������Ȃ��Ȃ��Ă�����
            {
                timer = 0f;

                int toSpawn = param.maxSpawnCount - currentCount; //���̎�ނ̓G�̍ő哯���o�����ƌ��݂̐��Ƃ̍��������߂�

                if (toSpawn >= 0) spawners[param.enemyType].SpawnEnemies(toSpawn); //���Ȃ��������G�𐶐�����
            }
        }
    }
}