using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;

    [SerializeField] private AudioSource hitMusic,coinMusic,appleMusic,checkPointMusic;

    private void Awake()
    {
        if(instance == null)  instance = this;
    }

    public void HitSound()
    {
        hitMusic.Play();
    }

    public void CoinSound()
    {
        coinMusic.Play();
    }

    public void AppleSound()
    {
        appleMusic.Play();
    }

    public void CheckPointSound()
    {
        checkPointMusic.Play();
    }
}
