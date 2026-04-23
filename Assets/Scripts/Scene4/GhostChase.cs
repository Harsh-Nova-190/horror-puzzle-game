using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GhostChase : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;

    [Header("Jumpscare Settings")]
    public GameObject jumpScarePanel;         // Panel that appears
    public AudioSource jumpScareSound;        // Optional scream sound
    public float scareDuration = 2f;

    [Header("UI (Optional)")]
    public Button restartButton;              // Optional restart button

    private bool hasScared = false;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        if (jumpScarePanel != null)
        {
            jumpScarePanel.SetActive(false); // Hide at start
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false); // Hide at start
        }
    }

    private void Update()
    {
        if (player == null || hasScared) return;

        // Move towards player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Flip sprite based on direction
        GetComponent<SpriteRenderer>().flipX = direction.x < 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasScared || !other.CompareTag("Player")) return;

        hasScared = true;

        // Disable player movement
        PlayerMovement movement = other.GetComponent<PlayerMovement>();
        if (movement != null)
        {
            movement.enabled = false;
        }

        // Activate jumpscare
        if (jumpScarePanel != null)
        {
            jumpScarePanel.SetActive(true);
        }

        if (jumpScareSound != null)
        {
            jumpScareSound.Play();
        }

        // Show restart button if available
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(RestartScene);
        }
        else
        {
            // Auto-restart if no button
            StartCoroutine(RestartAfterDelay());
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private System.Collections.IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(scareDuration);
        RestartScene();
    }
}
