using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSideScreenToDevice : MonoBehaviour
{
    public RenderTexture sideScreen;
    
    bool isTablet;

    void Start()
    {
        isTablet = CheckDeviceType.IsTablet();

        if(isTablet)
        {
            sideScreen.width = 480;
        }
        else
        {
            sideScreen.width = 256;
        }
    }
}
