using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private void Start()
    {
        SaveSchema s = new SaveSchema();
        s.mainMenuMusicVolume = 0.10f;
    }
}
