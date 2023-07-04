using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustRenderTexture : MonoBehaviour
{
    public static bool isTextureWidthChanged = false;

    public static RenderTexture newSideScreenTexture;

    public RenderTexture sideScreenTexture; 

    private bool _isTablet;

    private int tabletSideScreenWidth = 480;
    private int mobileSideScreenWidth = 256;

    void Awake()
    {
        _isTablet = CheckDeviceType.IsTablet();

        // ������ ������ �������� �������� �������
        if (_isTablet)
        {
            sideScreenTexture.width = tabletSideScreenWidth;
        }
        else
        {
            sideScreenTexture.width = mobileSideScreenWidth;
        }
        
        // �������� ����������� �������� � �����
        newSideScreenTexture = new RenderTexture(sideScreenTexture);

        // ������� ������ ��������
        sideScreenTexture.Release();

        isTextureWidthChanged = true;
    }
}
