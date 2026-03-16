using System.Collections;
using UnityEngine;
using StarterAssets;

public class SpeedBoost : MonoBehaviour
{
    [Header("Configuración")]
    public ThirdPersonController playerController; 
    public float boostedSpeed = 10f;              
    public float boostDuration = 5f;               

    private float originalSpeed;                 

    private void Awake()
    {
        if (playerController != null)
            originalSpeed = playerController.MoveSpeed;
    }

    public void ActivateBoost()
    {
        StartCoroutine(BoostRoutine());
    }

    private IEnumerator BoostRoutine()
    {
        // Aumenta la velocidad
        playerController.MoveSpeed = boostedSpeed;

        yield return new WaitForSeconds(boostDuration);

        // Restaura la velocidad original
        playerController.MoveSpeed = originalSpeed;
    }
}