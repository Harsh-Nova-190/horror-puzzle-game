using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerGhost : MonoBehaviour
{
    public GameObject ghost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ghost.SetActive(true);
        }
    }
}
