using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInterface : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }
}
