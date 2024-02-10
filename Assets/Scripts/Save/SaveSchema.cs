using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

[System.Serializable]
public class PlayerSchema
{
    // Geral
    public string playerUsername = "player";
    public Language language = Language.English;
  
}

[System.Serializable]
public enum Language
{
    Portuguese,
    English
}

[System.Serializable]
public class OptionsSchema
{
    // Music Volume
    public float mainMenuMusicVolume = 50f;
    public bool mainMenuMusicMuted = false;
}