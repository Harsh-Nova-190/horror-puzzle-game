using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.IO;

public class DoorManager3 : MonoBehaviour
{
    public AudioSource doorOpen;
    public bool isUnlocked = false;
    public string nextSceneName;
    public TextMeshProUGUI DoorText;

    private bool isPlayerNearby = false;

    private void Start()
    {
        if (DoorText != null)
            DoorText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (isUnlocked)
            {
                doorOpen.Play();
                StartCoroutine(LoadSceneDelay(2f));
            }
            else
            {
                ShowMessage("The door is locked.");
            }
        }
    }

    private IEnumerator LoadSceneDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
        ShowMessage("The door is now unlocked.");
    }

    private void ShowMessage(string message)
    {
        if (DoorText != null)
        {
            DoorText.text = message;
            DoorText.gameObject.SetActive(true);
            CancelInvoke(nameof(HideMessage));
            Invoke(nameof(HideMessage), 2f);
        }
    }

    private void HideMessage()
    {
        DoorText.gameObject.SetActive(false);
    }
}
