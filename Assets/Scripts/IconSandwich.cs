using UnityEngine;

public class IconSandwich : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public float ingredientDistanceY = 1f;
    public Vector3 ingredientScale = Vector3.one;
    public Transform instantiationLocation;

    private GameObject sandwichObjectEmpty;

    public void InstantiateSandwich(){
        sandwichObjectEmpty = new GameObject("Sandwich");
        GameObject[] iconList = gameManager.getIconList();
        for (int i = 0; i < iconList.Length; i++){
            Vector3 ingredientPosition = new Vector3(0f, i * ingredientDistanceY, 0f);
            GameObject ingredient = Instantiate(iconList[i], instantiationLocation.position + ingredientPosition, Quaternion.identity);
            ingredient.transform.parent = sandwichObjectEmpty.transform;
            ingredient.transform.localScale = ingredientScale;
        }
    }

    public void DestroySandwich(){
        if (sandwichObjectEmpty != null){
            foreach (Transform child in sandwichObjectEmpty.transform){
                Destroy(child.gameObject);
            }
            Destroy(sandwichObjectEmpty);
        }
    }
}
