using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour
{
    public GameObject textCompleat;
    public bool[] completedLevesArray;
    public void CheckWin(int i)
    {
       if(completedLevesArray[i-1] == true)
       {
            textCompleat.SetActive(true);
       }
       else
       {
            textCompleat.SetActive(false);
       }

    }
    void Start()
    {

        CompleatedLevelsData cld = SaveSystem.LoadProgress();
        this.completedLevesArray = cld.CompleatedLevelsArray;
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
