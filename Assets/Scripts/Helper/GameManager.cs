using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOver;

    [SerializeField] float startTime = 5f;

    bool isGameOver=false;
    float timeLeft;

    // public bool IsGameOver { get{ return isGameOver; } }
    public bool IsGameOver { get;private set; }

    // public bool IsGameOver => isGameOver;

    private void Start()
    {
        timeLeft = startTime;
    }

    private void Update()
    {
        DecreaseTime();
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    private void DecreaseTime()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        playerController.enabled = false;
        gameOver.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
