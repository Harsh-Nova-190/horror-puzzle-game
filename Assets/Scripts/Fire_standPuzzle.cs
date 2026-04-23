using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fire_standPuzzle : MonoBehaviour
{
    public static Fire_standPuzzle Instance;
    public TextMeshProUGUI interactionTextUI;

    public List<Fire_stand> lamps; // Assign lamps in correct order in Inspector
    public DoorPuzzle doorToUnlock;

    private int currentIndex = 0;
    private Coroutine messageCoroutine;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckLampOrder(Fire_stand activatedLamp)
    {
        if (activatedLamp == lamps[currentIndex])
        {
            currentIndex++;

            if (currentIndex >= lamps.Count)
            {
                ShowMessage("Puzzle solved!");
                Debug.Log("Puzzle solved!");
                doorToUnlock.UnlockDoor(); // Door disappears
            }
        }
        else
        {
            ShowMessage("Wrong order! Resetting...");
            Debug.Log("Wrong order! Resetting...");
            ResetPuzzle();
        }
    }

    public void ResetPuzzle()
    {
        currentIndex = 0;
        foreach (Fire_stand lamp in lamps)
        {
            lamp.ResetLamp();
        }
    }

    private void ShowMessage(string message)
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        messageCoroutine = StartCoroutine(DisplayMessage(message));
    }

    private IEnumerator DisplayMessage(string message)
    {
        interactionTextUI.text = message;
        interactionTextUI.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f); // Adjust time as needed

        interactionTextUI.text = "";
        interactionTextUI.gameObject.SetActive(false);
    }
}
