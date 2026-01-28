using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    [SerializeField] Transform towerRoot;
    [SerializeField] Button spawnButton;
    void Start()
    {
        towerRoot = GetComponentInParent<Transform>();
    }
    public void OnClickSpawnTower()
    {
        Instantiate(towerPrefab, towerRoot);
        spawnButton.gameObject.SetActive(false);
    }
}
