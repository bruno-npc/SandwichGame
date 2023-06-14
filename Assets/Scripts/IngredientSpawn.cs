using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawn : MonoBehaviour
{
    public List<GameObject> prefabs;  // Lista de prefabs a serem instanciados
    public Transform spawnPoint;  // Ponto de spawn dos prefabs
    public float yOffset = 1f;  // Alteração incremental no eixo Y
    public List<GameObject> spawnedPrefabs = new List<GameObject>();  // Lista de prefabs instanciados

    public List<GameObject> comparisonList = new List<GameObject>();  // Lista de comparação para verificar igualdade

    public void SpawnPrefab(int prefabIndex)
    {
        // Verifica se o índice do prefab é válido
        if (prefabIndex >= 0 && prefabIndex < prefabs.Count)
        {
            // Instancia um novo prefab com uma alteração no eixo Y
            GameObject newPrefab = Instantiate(prefabs[prefabIndex], spawnPoint.position + Vector3.up * (yOffset * spawnedPrefabs.Count), Quaternion.identity);
            spawnedPrefabs.Add(newPrefab);  // Adiciona o prefab à lista
        }
    }

    public void ClearLastPrefab()
    {
        // Verifica se há algum prefab para ser removido
        if (spawnedPrefabs.Count > 0)
        {
            // Obtém o último prefab instanciado
            GameObject lastPrefab = spawnedPrefabs[spawnedPrefabs.Count - 1];
            spawnedPrefabs.Remove(lastPrefab);  // Remove o último prefab da lista
            Destroy(lastPrefab);  // Destroi o último prefab instanciado
        }
    }

    public void ClearPrefabs()
    {
        // Destroi todos os prefabs instanciados e limpa a lista
        foreach (GameObject spawnedPrefab in spawnedPrefabs)
        {
            Destroy(spawnedPrefab);
        }
        spawnedPrefabs.Clear();
    }

private bool CompareLists()
{
    // Compara o tamanho das duas listas
    if (spawnedPrefabs.Count != comparisonList.Count)
    {
        return false;
    }

    for (int i = 0; i < spawnedPrefabs.Count; i++)
    {
        // Obtém os nomes dos objetos sem o sufixo "(Clone)" caso exista
        string spawnedName = spawnedPrefabs[i].name.Replace("(Clone)", string.Empty);
        string comparisonName = comparisonList[i].name.Replace("(Clone)", string.Empty);

        if (spawnedName != comparisonName)
        {
            return false;
        }
    }

    return true;
}

    public void comparar (){
        // Compara as duas listas quando uma nova instância é adicionada
        if (CompareLists())
        {
            Debug.Log("As listas são iguais!");
        }
        else if (!CompareLists())
        {
            Debug.Log("As listas são diferentes!");
        }
    }
}
