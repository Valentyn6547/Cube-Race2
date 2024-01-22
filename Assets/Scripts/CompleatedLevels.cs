using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CompleatedLevels : MonoBehaviour
{
    [HideInInspector]
    public bool[] compleatedLevelsArray;

    public void Win()
    {
        LoadProgress();
        compleatedLevelsArray[SceneManager.GetActiveScene().buildIndex - 1] = true;
        SaveProgress();
    }
    public void SaveProgress()
    {
        SaveSystem.SaveProgress(this);
    }

 
    public void LoadProgress()
    {
        CompleatedLevelsData cld = SaveSystem.LoadProgress();
        this.compleatedLevelsArray = cld.CompleatedLevelsArray;

    }
}
