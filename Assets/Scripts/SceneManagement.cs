using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ChangeScene(int sceneNumber)
    {
        if(sceneNumber==100)
            Application.Quit();
        else
            SceneManager.LoadScene(sceneNumber);

    }
}
