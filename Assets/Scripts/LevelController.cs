using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{

    [Header("Lives")]
    public TMP_Text livesText;
    public int lives;

    [Header("Rings")]
    public Transform ringUIParent;
    public GameObject ringUI;
    List<Ring> rings;

    [Header("Score")]
    public TMP_Text scoreText;
    int score = 0;

    [Header("Level Cleared")]
    public LevelCleared levelCleared;
    public GameObject miniMap;

    Gate gate;

    void Start()
    {
        Cursor.visible = false;

        InputCheck.isInputEnabled = true;
        SetLives();

        rings = new List<Ring>(FindObjectsOfType<Ring>());
        SetRings();

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        SetObstacles(obstacles);

        Bubble[] bubbles = FindObjectsOfType<Bubble>();
        SetBubbles(bubbles);

        Diamond[] diamonds = FindObjectsOfType<Diamond>();
        SetDiamonds(diamonds);

        gate = FindObjectOfType<Gate>();

        Finish finish = FindObjectOfType<Finish>();
        SetFinish(finish);
    }

    void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString("0000000");
    }

    void SetLives()
    {
        livesText.text = "X" + lives.ToString();
    }

    void SetRings()
    {
        foreach (Ring ring in rings)
        {
            Instantiate(ringUI, Vector3.zero, Quaternion.identity, ringUIParent);
            ring.onInteract.AddListener(RingPassed);
        }
    }

    void RingPassed()
    {
        try
        {
            if (rings.Count > 0)
            {
                GameObject ringUI = ringUIParent.GetChild(0).gameObject;
                Destroy(ringUI);
                rings.Remove(rings[0]);
                AddScore(500);

                if (rings.Count == 0)
                {
                    gate.OpenGate();
                }
            }
        }
        catch
        {
            Debug.Log("[LevelController.cs] - All rings passed.");
        }
    }

    void SetObstacles(Obstacle[] obstacles)
    {
        foreach (Obstacle obstacle in obstacles)
            obstacle.onInteract.AddListener(ObstaclePassed);
    }

    void ObstaclePassed()
    {
        lives--;
        livesText.text = "X" + lives.ToString();

        if (lives == 0)
        {
            OnLevelDone(false);
        }
    }

    void SetBubbles(Bubble[] bubbles)
    {
        foreach (Bubble bubble in bubbles)
            bubble.onInteract.AddListener(BubblePassed);
    }

    void BubblePassed()
    {
        lives++;
        livesText.text = "X" + lives.ToString();
        AddScore(1000);
    }

    void SetDiamonds(Diamond[] diamonds)
    {
        foreach (Diamond diamond in diamonds)
            diamond.onInteract.AddListener(delegate { AddScore(500); });
    }

    void SetFinish(Finish finish)
    {
        if (finish != null)
            finish.onInteract.AddListener(delegate { OnLevelDone(true); });
    }

    void OnLevelDone(bool win)
    {
        Cursor.visible = true;
        InputCheck.isInputEnabled = false;
        AddScore(win ? 3000 : 0);
        miniMap.SetActive(false);
        levelCleared.gameObject.SetActive(true);
        StartCoroutine(levelCleared.DisplayScore(score, win));
    }
}
