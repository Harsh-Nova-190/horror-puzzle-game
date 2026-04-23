using UnityEngine;

public class ParallaxBorderTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Find all parallax layers and disable them
            foreach (ParallaxLayer layer in FindObjectsOfType<ParallaxLayer>())
            {
                layer.DisableParallax();
            }
        }
    }
}
