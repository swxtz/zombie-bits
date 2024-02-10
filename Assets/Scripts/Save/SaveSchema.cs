using System.Collections;
using System.Collections.Generic;
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
