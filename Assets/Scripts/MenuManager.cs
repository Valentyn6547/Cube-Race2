using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject EndAnimUI;
    public void PlayLevelGame()
    {
        EndAnimUI.SetActive(true);
        Invoke("LoadGame", 0.5f);
       
    }  

    public void LoadSelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    
}
