using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    public List<GameObject> prefabs;  
    public Transform spawnPoint;  
    public float yOffset; 
    public List<GameObject> spawnedPrefabs = new List<GameObject>();

    public List<SandwichScriptabeObject> sandwichObject;

    [SerializeField] private SandwichScriptabeObject rSandwich;

    [SerializeField] private GameObject[] comparisonList;

    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private SoundRender sound;
    void Start(){
        randomSandwich();
    }


    private void Update()
    {
        SpawnBread();
    }

    private void randomSandwich (){
        rSandwich = sandwichObject[Random.Range(0, sandwichObject.Count)];
        gameManager.setIconList(rSandwich.ingredients);
        gameManager.setName(rSandwich.name);
        comparisonList = rSandwich.ingredients;
    }

    private void SpawnBread (){
        if (spawnedPrefabs.Count == 0)
        {
            GameObject newPrefab = Instantiate(prefabs[0], spawnPoint.position, Quaternion.Euler(0f, 90f, 0f));
            spawnedPrefabs.Add(newPrefab);
        }
        if (spawnedPrefabs.Count == 4)
        {
            GameObject newPrefab = Instantiate(prefabs[0], spawnPoint.position + Vector3.up * yOffset * 4, Quaternion.Euler(0f, 90f, 0f));
            spawnedPrefabs.Add(newPrefab);
        }
    }

    public void SpawnPrefab(int prefabIndex)
    {
        if (prefabIndex > 0 && spawnedPrefabs.Count <= 4)
        {
            GameObject newPrefab = Instantiate(prefabs[prefabIndex], spawnPoint.position + Vector3.up * yOffset * spawnedPrefabs.Count, Quaternion.identity);
            spawnedPrefabs.Add(newPrefab);
            sound.SpawnNewIngredient();
        }
    }

    public void ClearLastPrefab()
    {
        if (spawnedPrefabs.Count > 1)
        {
            if (spawnedPrefabs.Count == 5)
            {
                GameObject fifthPrefab = spawnedPrefabs[4];
                spawnedPrefabs.Remove(fifthPrefab);
                Destroy(fifthPrefab);
            }
            GameObject lastPrefab = spawnedPrefabs[spawnedPrefabs.Count - 1];
            spawnedPrefabs.Remove(lastPrefab);
            Destroy(lastPrefab);
        }
        sound.RemoveIngredient();
    }

    private bool CompareLists()
    {
        if (spawnedPrefabs.Count != comparisonList.Length)
        {
            return false;
        }

        for (int i = 0; i < spawnedPrefabs.Count; i++)
        {
            string spawnedName = spawnedPrefabs[i].name.Replace("(Clone)", string.Empty);
            string comparisonName = comparisonList[i].name.Replace("(Clone)", string.Empty);

            if (spawnedName != comparisonName)
            {
                return false;
            }
        }

        return true;
    }

    public void ClearPrefabs()
    {
        for (int i = spawnedPrefabs.Count - 1; i > 0; i--)
        {
            GameObject prefab = spawnedPrefabs[i];
            spawnedPrefabs.Remove(prefab);
            Destroy(prefab);
        }
    }

    public void comparar()
    {
        if (CompareLists())
        {
            gameManager.incrementScore(5);
            randomSandwich();
            ClearPrefabs();
        }
        else
        {
            gameManager.incrementScore(0);
            randomSandwich();
            ClearPrefabs();
        }
    }
}