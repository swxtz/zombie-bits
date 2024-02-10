using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

[System.Serializable]
public struct PlayerSchema
{
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

[System.Serializable]
public struct OptionsSchema
{
    // Music Volume
    public float mainMenuMusicVolume;
    public bool mainMenuMusicMuted;
}