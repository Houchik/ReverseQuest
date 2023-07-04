using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDeviceType : MonoBehaviour
{
    public static bool IsTablet()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        // ���� ������ ������ 0.65, �� ��� �� ���� �������, � ��� ��� ������ �������
        bool isTablet = aspectRatio > 0.65f;
        Debug.Log("Current Device Aspect Ratio: " + aspectRatio);

        return isTablet;
    }
}

public enum ENUM_Device_Type
{
    Tablet,
    Phone
}
