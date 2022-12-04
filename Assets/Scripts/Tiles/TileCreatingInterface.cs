using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileCreatingInterface : MonoBehaviour
{
    [SerializeField] private Transform newTileTransform;
    
    public static event Action<Tile,Transform> OnNewTileCreating;
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => { OnNewTileCreating?.Invoke(GetComponentInParent<Tile>(),newTileTransform); gameObject.SetActive(false); });
    }
}
