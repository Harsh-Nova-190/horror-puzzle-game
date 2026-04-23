using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 1f;
    private InteractableObject currentInteractable;

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckForInteractable()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange);

        currentInteractable = null;
        foreach (var hit in hits)
        {
            InteractableObject interactable = hit.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
