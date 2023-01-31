
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameInterface : MonoBehaviour {

    [SerializeField] private TMP_Text endText;
    [SerializeField] private Build_Controll buildControll;
    
    private CanvasGroup canvasGroup;

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void EnableEndInterface(string endText) {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        buildControll.towerToBuild = null;
        this.endText.text = endText;
    }
}
