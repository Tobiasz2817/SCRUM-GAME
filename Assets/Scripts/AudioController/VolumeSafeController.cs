using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class VolumeSafeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TextMeshProUGUI volumeTextUI = null;
    private void Start()
    {
        LoadValues();
    }
    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = (volume*100f).ToString("0.0");
    }
    public void SaveVolumeButton()//Podpi¹æ do przycisku, który zapisuje zmiany
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        LoadValues();
    }
    void LoadValues()
    {
        float volumeValue = 0;
        volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        //volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
