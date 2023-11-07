using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString("F0") + " m";
    }
}
