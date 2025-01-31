using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Animator animator;
    float collisionCooldown = 1f;
    float cooldownTimer = 0f;

    [SerializeField] float adjustSpeed = -2f;

    LevelGengerator levelGengerator;

    private void Start()
    {
        levelGengerator = FindFirstObjectByType<LevelGengerator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGengerator.ChangeChunkSpeed(adjustSpeed);
        AudioManager.instance.HitSound();
        animator.SetTrigger("Hit");
        cooldownTimer = 0f;
    }
}
