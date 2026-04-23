using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public AudioSource click;
    public DoorManager2 doorManager;
    private bool playerInRange = false;
    private bool isFlipped = false;

    void Update()
    {
        if (playerInRange && !isFlipped && Input.GetKeyDown(KeyCode.E))
        {
            isFlipped = true;
            doorManager.UnlockDoor();
            click.Play();
            UIManager.Instance.ShowMessage("The door is now unlocked.", 2f); // <- THIS LINE
            Debug.Log("Switch flipped.");
        }
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
