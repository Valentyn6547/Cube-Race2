using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompleatedLevelsData
{
    public bool[] CompleatedLevelsArray;

    public CompleatedLevelsData(CompleatedLevels cl)
    {
        this.CompleatedLevelsArray = cl.compleatedLevelsArray;
    }
    public CompleatedLevelsData()
    {
        this.CompleatedLevelsArray = new bool[5]{ false,false,false,false,false};
    }
}
