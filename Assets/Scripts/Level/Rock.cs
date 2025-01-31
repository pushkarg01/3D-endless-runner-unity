using UnityEngine;
using Unity.Cinemachine;

public class Rock : MonoBehaviour
{
    CinemachineImpulseSource CinemachineImpulseSource;
    [SerializeField] ParticleSystem collisionParticleSystem;
    [SerializeField] AudioSource soundRock;

    [SerializeField] float shakeModifier = 10f;
    [SerializeField] float collisionCoolDown = 1f;
    float collisionTimer = 1f;

    private void Awake()
    {
        CinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (collisionTimer < collisionCoolDown) return;
        FireImpluse();
        CollisionFX(other);
        collisionTimer = 0f;
    }

    private void FireImpluse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        float shakeIntensity = (1f / distance) * shakeModifier;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);

        CinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision other)
    {
        ContactPoint contactPoint = other.contacts[0];
        collisionParticleSystem.transform.position = contactPoint.point;
        collisionParticleSystem.Play();
        soundRock.Play();   
    }
}
