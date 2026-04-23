using UnityEngine;

public class ShadowAppear : MonoBehaviour
{
    public AudioSource scream;
    public GameObject shadowObject; // Drag your shadow GameObject here
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(ShowShadow());
        }
    }

    private System.Collections.IEnumerator ShowShadow()
    {
        shadowObject.SetActive(true);
        scream.Play();
        yield return new WaitForSeconds(0.5f);
        shadowObject.SetActive(false);
    }
}
