using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlickerInteractable : MonoBehaviour
{
    private Light2D light2D;
    public AudioSource flickerSound;
    private bool isPlayerNear = false;
    private bool isFlickering = false;

    [Header("Flicker Settings")]
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 0.1f;

    private void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.intensity = 0f;
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!isFlickering)
            {
                // Start flickering
                flickerSound.Play();
                InvokeRepeating(nameof(Flicker), 0f, flickerSpeed);
                isFlickering = true;
            }
            else
            {
                // Stop flickering
                flickerSound.Pause();
                CancelInvoke(nameof(Flicker));
                light2D.intensity = 0f;
                isFlickering = false;
            }
        }
    }

    private void Flicker()
    {
        if (light2D != null)
            light2D.intensity = Random.Range(minIntensity, maxIntensity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = false;
    }
    public bool IsFlickering()
    {
        return isFlickering;
    }

}
