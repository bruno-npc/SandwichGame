using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreviewSandwich : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private float distanceBetweenPrefabs;

    [SerializeField] private Transform spawnPointPreview;

    private string nameSandwichReceived = "";
    private GameObject[] prefabIcon;

     private List<GameObject> spawnedPrefabs = new List<GameObject>();


    void Update() {
        if (nameSandwichReceived != gameManager.getName()){
            nameSandwichReceived = gameManager.getName();
            textMesh.text = "Sandwich: \n" + nameSandwichReceived;
            ClearPrefabs();
            InstantiateAllPrefabs(gameManager.getIconList());
        }
    }


    public void InstantiateAllPrefabs(GameObject[] prefabSpawn){
        for (int i = 0; i < prefabSpawn.Length; i++){
            GameObject newPrefab = Instantiate(prefabSpawn[i], (spawnPointPreview.position + Vector3.up * distanceBetweenPrefabs * (spawnedPrefabs.Count + 1)), Quaternion.Euler(-35f, 90f, 0f));
            spawnedPrefabs.Add(newPrefab);
        }
    }

    public void ClearPrefabs(){
        for (int i = spawnedPrefabs.Count - 1; i >= 0; i--){
            GameObject prefab = spawnedPrefabs[i];
            spawnedPrefabs.Remove(prefab);
            Destroy(prefab);
        }
    }

}
