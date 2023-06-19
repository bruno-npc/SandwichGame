using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void RestartGame(){
        LoadScene("Countdown");
    }

    public void MainMenu(){
        LoadScene("MainMenu");
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

}