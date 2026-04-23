using System.Collections;
using TMPro;
using UnityEngine;

public class TextIntro : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float stayDuration = 1f;   // Time the text stays fully visible
    public float fadeDuration = 1f;   // Time it takes to fade out

    void Start()
    {
        StartCoroutine(DissappearText());
    }

    private IEnumerator DissappearText()
    {
        // Ensure text is visible
        textMesh.alpha = 1f;

        // Wait while fully visible
        yield return new WaitForSeconds(stayDuration);

        // Fade out
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            textMesh.alpha = Mathf.Lerp(1f, 0f, t); // Alpha decreases from 1 to 0
            elapsed += Time.deltaTime;
            yield return null;
        }
        textMesh.alpha = 0f; 
        textMesh.gameObject.SetActive(false);
    }
}
