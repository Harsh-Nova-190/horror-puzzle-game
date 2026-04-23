using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI messageText;

    private void Start()
    {
        if (messageText != null)
            messageText.alpha = 0f;
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowMessage(string message, float duration = 2f)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayMessage(message, duration));
    }

    private System.Collections.IEnumerator DisplayMessage(string message, float duration)
    {
        messageText.text = message;
        messageText.alpha = 1f;

        yield return new WaitForSeconds(duration);

        messageText.alpha = 0f;
    }
}