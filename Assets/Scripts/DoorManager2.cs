using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DoorManager2 : MonoBehaviour
{
    public bool isUnlocked = false;
    public string nextSceneName;
    public AudioSource openSound;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isUnlocked)
            {
                UIManager.Instance.ShowMessage("The door creaks open...");
                openSound.Play();
                StartCoroutine(LoadSceneAfterDelay(2f));
            }
            else
            {
                UIManager.Instance.ShowMessage("The door is locked.");
                Debug.Log("Door is locked.");
            }
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextSceneName);
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
        Debug.Log("Door unlocked!");
        UIManager.Instance.ShowMessage("You hear a click... the door is unlocked.");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
