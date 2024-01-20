using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vSyncManager
{

    public enum vSyncMode
    {
        On,
        Off
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVSyncMode(vSyncMode mode)
    {
        if(mode == vSyncMode.On)
        {
            QualitySettings.vSyncCount = 1;
        } else if(mode == vSyncMode.Off)
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
