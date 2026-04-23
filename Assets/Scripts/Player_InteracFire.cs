using UnityEngine;

public class Player_InteracFire : MonoBehaviour
{
    private GameObject fireStand;

    void Update()
    {
        if (fireStand != null && Input.GetKeyDown(KeyCode.E))
        {
            Fire_stand fireScript = fireStand.GetComponent<Fire_stand>();
            if (fireScript != null)
            {
                fireScript.Interact(gameObject); // Pass the player (this) GameObject
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LightPost"))
        {
            fireStand = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LightPost"))
        {
            fireStand = null;
        }
    }
}
