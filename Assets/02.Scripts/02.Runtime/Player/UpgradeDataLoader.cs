using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UpgradeDataLoader
{
    // [SerializeField]
    // public UpgradeData upgradeData;

    public List<UpgradeData> upgrade = new List<UpgradeData>();

    public void ParseCSV(TextAsset csvFile)
    {
        if (csvFile == null) return;

        string csvText = csvFile.text;
        string[] csvLine = csvText.Split('\n');

        for(int i=1;i<csvLine.Length;++i)
        {
            string line = csvLine[i];

            if(string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] lineValues = line.Split(',');

            UpgradeData data = new UpgradeData();

            data.ID = int.Parse(lineValues[0]);
            data.Name = lineValues[1];
            data.Tier = lineValues[2];
            data.StatType = (StatType)Enum.Parse(typeof(StatType),lineValues[3]);
            data.Value= float.Parse(lineValues[4]);
            data.Description=lineValues[5];

            upgrade.Add(data);
        }
    }
}   