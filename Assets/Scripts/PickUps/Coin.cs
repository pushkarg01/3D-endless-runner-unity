using UnityEngine;

public class Coin : PickUps
{
    ScoreManager scoreManager;
    [SerializeField] int scoreAmount = 100;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
    protected override void OnPickup()
    {
        AudioManager.instance.CoinSound();
        scoreManager.IncreaseScore(scoreAmount);
    }
}
