using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexGridLayoutManager : MonoBehaviour
{
    private FlexibleGridLayout flexibleGridLayout;

    private void Awake()
    {
        flexibleGridLayout = FindObjectOfType<FlexibleGridLayout>();
        flexibleGridLayout.enabled = true;
    }

    void Start()
    {
        flexibleGridLayout.enabled = false;
    }
}
