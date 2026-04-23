using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;
    public TextMeshProUGUI interactionTextUI;

    void Awake()
    {
        Instance = this;
        HideText();
    }

    public void ShowText(string message)
    {
        interactionTextUI.text = message;
        interactionTextUI.gameObject.SetActive(true);
        CancelInvoke(nameof(HideText));
        Invoke(nameof(HideText), 3f); // Hide after 3 seconds
    }

    public void HideText()
    {
        interactionTextUI.gameObject.SetActive(false);
    }
}
