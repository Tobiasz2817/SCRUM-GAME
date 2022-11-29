using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileInterface : MonoBehaviour
{
    public static event Action OnTileCreate;
    
    void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;

        GetComponentInChildren<Button>().onClick.AddListener(() => { OnTileCreate?.Invoke(); gameObject.SetActive(false); });
    }
}
