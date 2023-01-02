using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ImplantsInterface : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    
    [SerializeField]
    private CardInterface cardPrefab;

    [SerializeField] 
    private List<CardParemeters> cardParemetersList;

    private void Start() {
        List<CardParemeters> tmp = new List<CardParemeters>(cardParemetersList);
        
        for (int i = 0; i < 3; i++) {
            int randomIndex = Random.Range(0, tmp.Count); 
            CardInterface card = Instantiate(cardPrefab,transform);
            
            card.SetCard(tmp[randomIndex]);
            tmp.Remove(tmp[randomIndex]);
        }
    }

    private void OnEnable() {
        CardEventsHandler.OnModificateHealth += DisableParent;
        CardEventsHandler.OnModificateMovement += DisableParent;
        CardEventsHandler.OnModificateSpawn += DisableParent;
    }
    private void OnDisable() {
        CardEventsHandler.OnModificateHealth -= DisableParent;
        CardEventsHandler.OnModificateMovement -= DisableParent;
        CardEventsHandler.OnModificateSpawn -= DisableParent;
    }

    private void DisableParent(CardParemeters cardParemeters) {
        parent.gameObject.SetActive(false);
    }
}
