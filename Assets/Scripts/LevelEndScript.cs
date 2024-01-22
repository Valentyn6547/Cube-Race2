using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndScript : MonoBehaviour
{

    public void LoadNextLevel()
    {
    
        SceneManager.LoadScene("SelectLevel");
    }
}
