using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInterface : MonoBehaviour
{
    private CardParemeters cardParemeters;

    [SerializeField] 
    private TMP_Text text;
    [SerializeField] 
    private Button button;
    
    public void SetCard(CardParemeters cardParemeters) {
        text.text = cardParemeters.text;

        button.onClick.AddListener(() => CardEventsHandler.InvokeEvent(cardParemeters));
    }
}