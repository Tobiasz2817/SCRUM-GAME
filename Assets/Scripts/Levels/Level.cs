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

    public LevelInfo levelInfo;

    #region Unity Events
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    
    void OnEnable()
    {
        button.onClick.AddListener(InvokeEvent);
        DisablePanel();
    }
    
    void OnDisable()
    {
        button.onClick.RemoveListener(InvokeEvent);
    }
    
    #endregion
   
    public void SetUpLevel(LevelInfo levelInfo)
    {
        this.levelInfo.isReached = levelInfo.isReached;
        this.levelInfo.nameLevel = levelInfo.nameLevel;
        this.levelText.text = this.levelInfo.nameLevel;
    }

    public void EnablePanel()
    {
        PanelActivity(new PanelActivity() { endValueFade = 1, isInteractable = true, isRaycast = true});
    }
    public void DisablePanel()
    {
        PanelActivity(new PanelActivity() { endValueFade = 0, isInteractable = false, isRaycast = false});
    }
    private void InvokeEvent()
    {
        OnClick?.Invoke(this);
    }
    
    public void PanelActivity(PanelActivity panelActivity)
    {
        _canvasGroup.DOFade(panelActivity.endValueFade, duration);
        _canvasGroup.interactable = panelActivity.isInteractable;
        _canvasGroup.blocksRaycasts = panelActivity.isRaycast;

        levelInfo.isReached = panelActivity.endValueFade == 1 ? true : false;
    }
}
[Serializable]
public struct LevelInfo
{
    public bool isReached;
    public string nameLevel;
}

public struct PanelActivity
{
    public int endValueFade;
    public bool isInteractable;
    public bool isRaycast;
}