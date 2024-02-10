using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    private string saveLocation = "Saves";
    private string saveName = "default";

    private void Awake()
    {

        Save save = new Save();
        save.CreateSave();
    }
}
