using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    [SerializeField] TextAsset csvFile;

    UpgradeDataLoader loader;
    Dictionary<int, UpgradeData> upgradeDict;
    HashSet<int> selectedCardID;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        loader = new UpgradeDataLoader();
        loader.ParseCSV(csvFile);

        BuildDictionary();
        ResetSelection();
    }

    public void BuildDictionary()
    {
        upgradeDict = new Dictionary<int, UpgradeData>();

        foreach (var data in loader.upgrade)
        {
            upgradeDict.Add(data.ID, data);
        }
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        // 고르지 않은 카드들을 available 리스트에 배치
        List<UpgradeData> available = new List<UpgradeData>();

        // upgradeData를 순회하며 검사
        foreach (var data in loader.upgrade)
        {
            // 이미 사용한 카드가 아니라면 = HashSet에 배치된 ID가 아니라면
            if (!selectedCardID.Contains(data.ID))
            {
                // 사용 가능하다고 인식시켜 available 리스트에 배치한다.
                available.Add(data);
            }
        }

        // 복사생성자 역할을 할 임시 데이터 리스트를 생성해 현재 available리스트의 데이터들을 대입한다.
        List<UpgradeData> tempData = new List<UpgradeData>(available);

        // tempData에 저장된 카드들 중, count 수치만큼 출력할 candidate리스트를 만든다.
        List<UpgradeData> candidate = new List<UpgradeData>();

        // count 수치만큼 반복하여 랜덤으로 tempData의 데이터를 호출해 candidate리스트에 배치한다.
        for (int i = 0; i < count; ++i)
        {
            int rand = Random.Range(0, tempData.Count);

            candidate.Add(tempData[rand]);

            // 선택된 데이터는 tempData리스트에서 제거한다.
            tempData.RemoveAt(rand);
        }

        return candidate;
    }

    public void MarkSelected(int cardID)
    {
        selectedCardID.Add(cardID);
    }

    public void ResetSelection()
    {
        selectedCardID.Clear();
    }
}