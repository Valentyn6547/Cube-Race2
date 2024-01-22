using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem 
{
    private static string optionFileName = "option11.ukr";
    private static string progressFileName = "progress19.ukr";
    public static void SaveOptions(Options o)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + optionFileName;
        FileStream stream = new FileStream(path, FileMode.Create);
        OptionsData data = new OptionsData(o);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveOptions(OptionsData data)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + optionFileName;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static OptionsData LoadOptionsData()
    {
        string path = Application.persistentDataPath + optionFileName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            OptionsData data = formatter.Deserialize(stream) as OptionsData;
            stream.Close();

            return data;
        }
        else
        {
            SaveOptions(new OptionsData(1, 0.4f, true));
         
            return LoadOptionsData();
        }
    }

    public static void SaveProgress(CompleatedLevels cl)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + progressFileName;
        FileStream stream = new FileStream(path, FileMode.Create);
        CompleatedLevelsData cld = new CompleatedLevelsData(cl);

        formatter.Serialize(stream, cld);
        stream.Close();


    }
    public static void SaveProgress(CompleatedLevelsData cld)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + progressFileName;
        FileStream stream = new FileStream(path, FileMode.Create);
        

        formatter.Serialize(stream, cld);
        stream.Close();


    }

    public static CompleatedLevelsData LoadProgress()
    {
        string path = Application.persistentDataPath + progressFileName;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            CompleatedLevelsData data = formatter.Deserialize(stream) as CompleatedLevelsData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Saved file not found in: " + path);
            SaveProgress(new CompleatedLevelsData());
            return LoadProgress();
        }
        
    }
}
