using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public static void SaveHighscore(int highScoreData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.highscore";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScoreData data = new HighScoreData(highScoreData);

        formatter.Serialize(stream,data);
        stream.Close();
        JSBridge.SendHighscoreSignal(highScoreData);
    }

    public static HighScoreData LoadHighscore ()
    {
        string path = Application.persistentDataPath + "/player.highscore";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighScoreData data = formatter.Deserialize(stream) as HighScoreData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Highscore not fount in" + path);
            return null;
        }
    }
    public static void SaveControls(bool controlMouse, bool controlKeyboard)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.controlPrefs";
        FileStream stream = new FileStream(path, FileMode.Create);

        ControlPrefData data = new ControlPrefData(controlMouse, controlKeyboard);
        formatter.Serialize(stream,data);
        stream.Close();
    }
    public static ControlPrefData LoadControls ()
    {
        string path = Application.persistentDataPath + "/player.controlPrefs";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ControlPrefData data = formatter.Deserialize(stream) as ControlPrefData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Control preferences not fount in" + path);
            return new ControlPrefData(false, true);
        }
    }
    
}
