using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string interactionText = "This object has no message.";
    private Fire_stand fire;

    public void Interact()
    {
        // Call this when the player presses "E" near this object
        InteractionUI.Instance.ShowText(interactionText);
    }
}
