using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInterface : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TMP_Text levelText;
    
    [SerializeField] private float duration;
    public static event Action<LevelInterface> OnClick;

    private CanvasGroup _canvasGroup;

    public TileDependenciesLevelData tileDependenciesLevelData;

    #region Unity Events
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    
    void OnEnable()
    {
        button.onClick.AddListener(InvokeEvent);
        DisablePanel(0);
    }
    
    void OnDisable()
    {
        button.onClick.RemoveListener(InvokeEvent);
    }
    
    #endregion
   
    public void SetUpLevel(TileDependenciesLevelData levelDataTile)
    {
        this.levelText.text = levelDataTile.nameLevel;

        this.tileDependenciesLevelData = levelDataTile;
    }

    public void EnablePanel(float duration)
    {
        PanelActivity(duration,1, true, true);
    }
    public void DisablePanel(float duration)
    {
        PanelActivity(duration,0, false, false);
    }
    private void InvokeEvent()
    {
        OnClick?.Invoke(this);
    }
    
    public void PanelActivity(float duration,float endValueFade, bool isInteractable, bool isRaycast)
    {
        _canvasGroup.DOFade(endValueFade, duration);
        _canvasGroup.interactable = isInteractable;
        _canvasGroup.blocksRaycasts = isRaycast;
    }

    public float GetDuration() {
        return duration;
    }
}
