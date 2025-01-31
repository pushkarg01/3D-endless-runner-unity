using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float minFOV =35f, maxFOV=85f;

    [SerializeField] float zoomDuration = 1f;
    [SerializeField] float zoomSpeedModifier = 5f;
    CinemachineCamera cam;

    [SerializeField] ParticleSystem speedUpParticals;

    private void Awake()
    {
        cam = GetComponent<CinemachineCamera>();
    }
    public void ChangeCameraPOV(float speedAmount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(speedAmount));

        if (speedAmount > 0)
        {
            speedUpParticals.Play();
        }
    }

    IEnumerator ChangeFOVRoutine(float speedAmount)
    {
        float startFOV = cam.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + speedAmount *zoomSpeedModifier,minFOV,maxFOV);

        float elapsedTime = 0f;
        while (elapsedTime <zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            cam .Lens.FieldOfView= Mathf.Lerp(startFOV,targetFOV,t);
            yield return null;
        }

        cam.Lens.FieldOfView = targetFOV;
    }
}
