using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCleared : MonoBehaviour
{
    public TMP_Text resultText;
    public string levelName;
    public TMP_Text scoreText;
    public Button nextLevel;

    public IEnumerator DisplayScore(int totalScore, bool win)
    {
        int score = 0;

        if (win)
        {
            resultText.text = levelName + "\nCOMPLETE";
            nextLevel.interactable = true;
        }
        else
        {
            resultText.text = "GAME\nOVER";
            nextLevel.interactable = false;
        }

        while (score < totalScore)
        {
            score = Mathf.Clamp(score += 10, 0, totalScore);
            scoreText.text = score.ToString();

            yield return new WaitForEndOfFrame();
        }
    }
}
