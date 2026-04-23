using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    public bool isUnlocked = false;

    public void UnlockDoor()
    {
        Debug.Log("Door unlocked!");
        gameObject.SetActive(false); 
    }
}
