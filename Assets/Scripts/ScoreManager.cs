using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private const string scoresKey = "Scores";

    private List<int> scores = new List<int>();

    private string scoreTotal = "";

    public void AddScore(int score){
        SaveScores(LoadScores() + score.ToString() + "\n");
        UpdateScoreArray(LoadScores());
    }

    private void UpdateScoreArray(string scoreString){
        string[] scoreLines = scoreString.Split('\n');
        foreach (string scoreLine in scoreLines)
        {
            if (!string.IsNullOrEmpty(scoreLine))
            {
                int score;
                if (int.TryParse(scoreLine, out score))
                {
                    scores.Add(score);
                }
            }
        }
        //Ordenação decrescente da lista
        scores.Sort((a, b) => b.CompareTo(a));

        foreach(int score in scores){
            scoreTotal += score + "\n";
        }
        scoreText.text = scoreTotal;
    }


    private void SaveScores(string totalScore){
        PlayerPrefs.SetString(scoresKey, totalScore);
    }

    private string LoadScores(){
        return PlayerPrefs.GetString(scoresKey);
    }

}
