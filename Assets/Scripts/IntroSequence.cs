using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroSequence : MonoBehaviour
{
    public Image fadePanel;
    public TextMeshProUGUI introText;
    public TextMeshProUGUI Scene1;
    public float fadeDuration = 2f;
    public float textDelay = 1f;
    public float totalDelayBeforeMove = 4f;

    public GameObject player;

    private PlayerMovement playerMovement;
    private Animator animator;

    void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        animator = player.GetComponent<Animator>();

        playerMovement.enabled = false;

        // Ensure idle animation is set
        if (animator != null)
        {
            animator.SetBool("isRunning", false);
        }

        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        // Fade from black
        float t = 0;
        Color panelColor = fadePanel.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            panelColor.a = Mathf.Lerp(1, 0, t / fadeDuration);
            fadePanel.color = panelColor;
            yield return null;
        }
        fadePanel.gameObject.SetActive(false);

        // Show text
        yield return new WaitForSeconds(textDelay);
        introText.alpha = 1;
        Scene1.alpha = 1;

        // Wait and enable movement
        yield return new WaitForSeconds(totalDelayBeforeMove - textDelay);
        introText.alpha = 0;
        Scene1.alpha = 0;
        playerMovement.enabled = true;
    }
}
