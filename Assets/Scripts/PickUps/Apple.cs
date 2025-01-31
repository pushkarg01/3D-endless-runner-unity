using UnityEngine;

public class Apple : PickUps
{
    [SerializeField] float adjustSpeed = 3f;
    LevelGengerator levelGengerator;

    public void Init(LevelGengerator levelGengerator)
    {
        this.levelGengerator = levelGengerator;
    }
    protected override void OnPickup()
    {
        AudioManager.instance.AppleSound();
        levelGengerator.ChangeChunkSpeed(adjustSpeed);
    }
}
