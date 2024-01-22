using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class OptionsData 
{
    public int levelDifficulty;
    public float volume;
    public bool fullscreen;
    

    
    public OptionsData(Options o)
    {
        try
        {
        
            levelDifficulty = o.dropDown.value;
            volume = o.volumeSlider.value;
            fullscreen = o.fullscreenToggle.isOn;
        }
        catch(System.Exception e)
        {
            Debug.Log("Save Error");
        }
      
    }
    public OptionsData(int ld, float v, bool f)
    {
        levelDifficulty = ld;
        volume = v;
        fullscreen = f;
    }

 

}
