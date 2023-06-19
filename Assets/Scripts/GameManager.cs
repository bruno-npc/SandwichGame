using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int score;
    [SerializeField] private string nameSandwich;
    private GameObject[] prefabIcon;

    [SerializeField] private GameObject scoreObject;
    [SerializeField] private TextMeshProUGUI textMesh;

    public float totalTime = 120f; //120f;
    public TextMeshProUGUI countdownText;

    private float currentTime;

    [SerializeField] private SoundRender sound;
    [SerializeField] private ScoreManager scoreManager;

    public bool gameOn;

    void Start() {
        gameOn = true;
        textMesh = scoreObject.GetComponent<TextMeshProUGUI>();
        currentTime = totalTime;
        UpdateCountdownText();
        sound.ThemePlay();
    }

    void Update() {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                EndGame();
            }
            UpdateCountdownText();
        }
    }

    private void UpdateCountdownText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (currentTime <= 10f){
            countdownText.color = Color.red;
        }
    }

    private void EndGame()
    {
        gameOn = false;
        scoreManager.AddScore(this.score);
    }

    public void incrementScore(int value){
        score += value;
        textMesh.text = "Money: " + score;
    }

    public int getScore(){
        return score;
    }

    public void setName (string nameReceived){
        this.nameSandwich = nameReceived;
    }

    public string getName (){
        return this.nameSandwich;
    }

    public void setIconList(GameObject[] prefabs){
        this.prefabIcon = prefabs;
    }

    public GameObject[] getIconList(){
        return this.prefabIcon;
    }
}
