using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileCreatingInterface : MonoBehaviour
{
    [SerializeField] private Transform newTileTransform;
    [SerializeField] private Transform spawnPoint;
    public static event Action<Tile,Transform> OnNewTileCreating;

    private Tile myTile;
    
    private void Awake()
    {
        myTile = GetComponentInParent<Tile>();
        GetComponent<Button>().onClick.AddListener(ButtonActionInvoker);
    }

    private void ButtonActionInvoker()
    {
        OnNewTileCreating?.Invoke(myTile,newTileTransform);
        myTile.tilePoints.spawnPositions.Remove(spawnPoint);
        gameObject.SetActive(false);
    }
}
