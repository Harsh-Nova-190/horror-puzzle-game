using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TVTrigger : MonoBehaviour
{
    public Animator tvAnimator;              // Animator component
    public AudioSource tvAudio;
    public Light2D tvLight;

    private bool hasPlayed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasPlayed || !other.CompareTag("Player")) return;

        // Trigger TV animation
        if (tvAnimator != null)
            tvAnimator.SetTrigger("TurnOn");

        // Play audio
        if (tvAudio != null)
            tvAudio.Play();

        // Turn on light
        if (tvLight != null)
            tvLight.intensity = 1f;

        hasPlayed = true;
    }
}
