using UnityEngine;

public class LightActivator : MonoBehaviour
{
    [Header("Configuration")]
    public Light targetLight;        
    public Color lightColor = Color.yellow;
    public float intensity = 3f;

    public void ActivateLight()
    {
        if (targetLight != null)
        {
            targetLight.enabled = true;
            targetLight.color = lightColor;
            targetLight.intensity = intensity;
        }
    }
}