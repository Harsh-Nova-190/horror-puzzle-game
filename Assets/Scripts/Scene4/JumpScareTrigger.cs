using UnityEngine;
using UnityEngine.UI;

public class JumpScareTrigger : MonoBehaviour
{
    public GameObject jumpScarePanel;
    public AudioSource scareSound;

    private void Start()
    {
        jumpScarePanel.SetActive(false);
    }

    public void TriggerJumpScare()
    {
        jumpScarePanel.SetActive(true);
        scareSound.Play();

        Animator animator = jumpScarePanel.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("JumpScare_Anim");
        }

        // Optional: restart game or hide panel after delay
        Invoke(nameof(ResetScene), 2.5f);
    }

    private void ResetScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
