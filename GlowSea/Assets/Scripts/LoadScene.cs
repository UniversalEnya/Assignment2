using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public int nextScene;

    public void OnTriggerEnter()
    {
        SceneManager.LoadScene(nextScene);
    }
}

