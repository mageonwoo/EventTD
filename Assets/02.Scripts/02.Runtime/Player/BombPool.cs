using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 현 VS에는 포탄을 굳이 Object Pool로 관리할 필요는 없지만,
/// 최적화에 대한 것을 고려했을 때 반드시 제작해 둬야할 기능이라고 판단함.
/// </summary>
public class BombPool : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] int preCount = 3;

    readonly List<GameObject> listBombs = new List<GameObject>(256);

    void Awake()
    {
        ReadyBombs(preCount);
    }

    void ReadyBombs(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            var bomb = Instantiate(bombPrefab);
            bomb.transform.SetParent(transform, false);
            bomb.SetActive(false);
            listBombs.Add(bomb);
        }
    }

    public GameObject Get(Vector3 position, Quaternion rotation)
    {
        // 요청해서 받은 임시 결과물 (request) 관례상 임시 변수명
        GameObject req = null;

        // 리스트에서 하나 집어서 활성화
        for (int i = 0; i < listBombs.Count; ++i)
        {
            if (listBombs[i] != null && !listBombs[i].activeSelf)
            {
                req = listBombs[i];
                break;
            }
        }

        // 추가요청
        if (req == null)
        {
            var newBomb = Instantiate(bombPrefab);
            newBomb.transform.SetParent(transform, false);
            newBomb.SetActive(false);
            listBombs.Add(newBomb);
            req = newBomb;
        }

        req.transform.SetPositionAndRotation(position, rotation);
        req.SetActive(true);

        return req;
    }

    public void ClearAll()
    {
        for (int i = 0; i < listBombs.Count; ++i)
        {
            if (listBombs[i] != null)
                listBombs[i].SetActive(false);
        }
    }

}
