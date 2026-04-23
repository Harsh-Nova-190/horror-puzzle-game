using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Fire_stand : MonoBehaviour
{
    public int FireStand; // This acts like lampID
    public Animator anim;
    private bool isOn = false;
    public new GameObject light;

    private void Start()
    {
        if (anim == null)
            anim = GetComponent<Animator>();

        anim.SetBool("isLampOn", false);

        if (light != null)
            light.SetActive(false);
    }

    public void Interact(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement != null && playerMovement.HasTorch())
        {
            if (!isOn)
            {
                isOn = true;
                anim.SetBool("isLampOn", true);

                if (light != null)
                    light.SetActive(true);

                // 🔗 Notify puzzle logic
                Fire_standPuzzle.Instance.CheckLampOrder(this);
            }
        }
        else
        {
            Debug.Log("Player needs a torch to interact with this fire stand.");
        }
    }

    public void ResetLamp()
    {
        isOn = false;
        anim.SetBool("isLampOn", false);

        if (light != null)
            light.SetActive(false);
    }

    public bool IsOn() => isOn;
}
