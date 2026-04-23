using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public List<Fire_stand> lamps;
    public GameObject ghost; // Assign the Ghost GameObject

    private void Update()
    {
        if (AllLightsOff())
        {
            if (!ghost.activeInHierarchy)
                ghost.SetActive(true);
        }
        else
        {
            if (ghost.activeInHierarchy)
                ghost.SetActive(false);
        }
    }

    private bool AllLightsOff()
    {
        foreach (Fire_stand lamp in lamps)
        {
            if (lamp.IsOn())
                return false;
        }
        return true;
    }
}
