using System.Collections;
using UnityEngine;
using Unity.Cinemachine;

public class CameraShaker : MonoBehaviour
{
    [Header("Configuration")]
    public float duration = 0.5f;
    public float magnitude = 3f;

    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        noise = GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake()
    {
        if (noise != null)
            StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        // Activa el shake
        noise.AmplitudeGain = magnitude;

        yield return new WaitForSeconds(duration);

        // Lo apaga suavemente
        noise.AmplitudeGain = 0f;
    }
}