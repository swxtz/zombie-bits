using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SavePlayerSchema
{
    public float mainMenuMusicVolume;

    // Geral
    public string playerUsername;
    public Language language;
  
}

[System.Serializable]
public enum Language
{
    Portuguese,
    English
}
