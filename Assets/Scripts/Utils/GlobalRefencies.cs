using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalRefencies : MonoBehaviour
{
    public static GlobalRefencies Instance { get; set; }

    public GameObject bulletImpactEffectPrefab;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }
}
