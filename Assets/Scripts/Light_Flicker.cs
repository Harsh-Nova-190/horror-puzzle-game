using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light_Flicker : MonoBehaviour
{
    private Light2D light2D;

    [Header("Flicker Settings")]
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 0.1f;

    private void Start()
    {
        light2D = GetComponent<Light2D>();
        InvokeRepeating(nameof(Flicker), 0f, flickerSpeed);
    }

    private void Flicker()
    {
        if (light2D != null)
        {
            light2D.intensity = Random.Range(minIntensity, maxIntensity);
        }
    }
}