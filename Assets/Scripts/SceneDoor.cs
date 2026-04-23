using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDoor : MonoBehaviour
{
    public string sceneToLoad;
    private bool playerInRange;
    public AudioSource doorOpen;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            doorOpen.Play();
            StartCoroutine(LoadNextSceneDelay(2f));
        }
    }

    private IEnumerator LoadNextSceneDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneToLoad);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            InteractionUI.Instance.ShowText("Press E to open the door.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            InteractionUI.Instance.HideText();
        }
    }
}
