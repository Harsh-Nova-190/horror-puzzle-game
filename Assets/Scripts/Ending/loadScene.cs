using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadNextScene(7f));    
    }

    IEnumerator LoadNextScene (float time)
    {
        yield return new WaitForSeconds( time );
        SceneManager.LoadScene("Awake");
    } 
}
