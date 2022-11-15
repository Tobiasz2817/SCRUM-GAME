using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text levelText;
    
    [SerializeField] private float duration;

    public static event Action<Level> OnClick;

    private CanvasGroup _canvasGroup;

    private bool isGained = false;
    public bool IsGained { private set => isGained = value; get => isGained; }

    #region Unity Events
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    
    void OnEnable()
    {
        _canvasGroup.DOFade(0, duration);
        
        button.onClick.AddListener(InvokeEvent);
    }
    
    void OnDisable()
    {
        button.onClick.RemoveListener(InvokeEvent);
    }
    
    #endregion
   
    public void SetUpLevel(string levelText)
    {
        this.levelText.text = levelText;
        name = levelText;
    }

    private void InvokeEvent()
    {
        OnClick?.Invoke(this);
    }
    
    public void EnablePanelFade()
    {
        _canvasGroup.DOFade(1, duration);

        IsGained = true;
    }
}
