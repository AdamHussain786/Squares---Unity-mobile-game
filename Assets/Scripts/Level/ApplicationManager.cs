using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ApplicationManager : MonoBehaviour
{
    void Start()
    {
        //Debug.Log(Application.persistentDataPath);
    }

    public static void SeriouslyDeleteAllSaveFiles()
    {
        string path = Application.persistentDataPath + "/scores/";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete(true);
        Directory.CreateDirectory(path);
    }

    
}
