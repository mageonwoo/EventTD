using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// EnemyTypeSO = 적 데이터
/// EnemyPool = Queue<GameObject> 창고
/// - 필드로 SO를 배열화 시킨다.
/// - foreach로 설정한 수만큼 반복해서 데이터를 Queue에 집어넣어 준비시킨다
/// - 꺼내는 로직/반납하는 로직 만들고 Pool로직은 끝낸다.
/// </summary>
public class EnemyPool : MonoBehaviour
{
    [SerializeField] EnemyTypeSO[] enemyType;
    [SerializeField] WaveDataSO waveData;
    [SerializeField] int poolSize = 10;

    Queue<GameObject>[] queueEnemy;

    void Awake()
    {
        Init(poolSize);
    }

    void Init(int count)
    {
        queueEnemy = new Queue<GameObject>[waveData.MaxWaveIdx];

        for (int i = 0; i < waveData.MaxWaveIdx; ++i)
        {
            queueEnemy[i] = new Queue<GameObject>();
        }

        for (int i = 0; i < enemyType.Length; ++i)
        {
            for (int j = 0; j < count; ++j)
            {
                var enemy = Instantiate(enemyType[i].EnemyPrefab);

                enemy.transform.SetParent(transform, false);
                enemy.SetActive(false);
                queueEnemy[i].Enqueue(enemy);
            }
        }
    }

    public GameObject Get(int index)
    {
        if (queueEnemy[index].Count > 0)
        {
            GameObject enemy = queueEnemy[index].Dequeue();
            enemy.SetActive(true);

            return enemy;
        }
        else
        {
            var enemy = Instantiate(enemyType[index].EnemyPrefab, transform);

            enemy.SetActive(true);

            return enemy;
        }
    }

    public void Return(GameObject enemy)
    {
        var bridge = enemy.GetComponentInChildren<EnemyPoolBrid>();
        var hp = enemy.GetComponentInChildren<EnemyHP>(true);

        if (enemy.activeSelf == false) return;

        hp.HPReset();
        enemy.SetActive(false);

        queueEnemy[bridge.enemyLev].Enqueue(enemy);
    }
}
