using UnityEngine;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private GameManager gameManager;

    void Update() {
        if (gameScreen.activeSelf && !gameManager.gameOn){
            gameScreen.SetActive(false);
            endGameScreen.SetActive(true);
        }
        else if (!gameScreen.activeSelf && gameManager.gameOn){
            gameScreen.SetActive(true);
            endGameScreen.SetActive(false);
        }
    }
}
