using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Dropdown dropDown;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;


    public void SaveOptions()
    {
      
        SaveSystem.SaveOptions(this);
    }
    public void Start()
    {
        FindObjectOfType<Options>().LoadOptions();
      
    }
   
    public void LoadOptions()
    {
        OptionsData data = SaveSystem.LoadOptionsData();
        try
        {
          
            this.dropDown.value = data.levelDifficulty;
            this.dropDown.RefreshShownValue();
            this.volumeSlider.value = data.volume;
            this.fullscreenToggle.isOn = data.fullscreen;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Load Error");
        }
    }
}
