using UnityEngine;

public class LightPuzzleManager : MonoBehaviour
{
    public LightFlickerInteractable[] puzzleLights; // Lights to check
    public bool[] correctPattern; // Desired light states
    public DoorManager3 door; // The door to unlock
    public TMPro.TextMeshProUGUI statusText; // Optional: show "Unlocked!" message
    private bool isSolved = false;

    private void Update()
    {
        if (!isSolved && CheckPattern())
        {
            door.UnlockDoor();
            isSolved = true;

            if (statusText != null)
            {
                statusText.text = "You heard a click... the door is unlocked.";
                Invoke(nameof(ClearText), 3f);
            }
        }
    }

    private bool CheckPattern()
    {
        for (int i = 0; i < puzzleLights.Length; i++)
        {
            if (puzzleLights[i].IsFlickering() != correctPattern[i])
                return false;
        }
        return true;
    }

    private void ClearText()
    {
        statusText.text = "";
    }
}
