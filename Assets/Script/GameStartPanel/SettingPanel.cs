using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1.0f); // 默认音量为1.0
        volumeSlider.value = savedVolume;
        volumeSlider.onValueChanged.AddListener((value) =>
        {
            AudioManager.instance.SetVolume(value);
        });
    }
}
