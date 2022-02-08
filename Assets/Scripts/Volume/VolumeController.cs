using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;

    [SerializeField]
    private Slider soundsVolumeSlider;

    public Action<float> OnSaveMusicVolumeSettings;
    public Action<float> OnSaveSoundsVolumeSettings;

    private void OnEnable()
    {
        var canvasMenu = GameObject.Find("Canvas");
        var musicVolumeSliderGO = canvasMenu.transform.Find("OptionsMenu/MusicVolumeSlider");
        var soundsVolumeSliderGO = canvasMenu.transform.Find("OptionsMenu/SoundsVolumeSlider");

        musicVolumeSlider = musicVolumeSliderGO.GetComponent<Slider>();
        soundsVolumeSlider = soundsVolumeSliderGO.GetComponent<Slider>();

        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        soundsVolumeSlider.value = PlayerPrefs.GetFloat("GameSoundsVolume", 0.75f);

        SaveMusicVolumeSettings(musicVolumeSlider.value);
        SaveSoundsVolumeSettings(soundsVolumeSlider.value);

        musicVolumeSlider.onValueChanged.AddListener(SaveMusicVolumeSettings);
        soundsVolumeSlider.onValueChanged.AddListener(SaveSoundsVolumeSettings);
    }


    public void SaveMusicVolumeSettings(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        OnSaveMusicVolumeSettings?.Invoke(value);
    }

    public void SaveSoundsVolumeSettings(float value)
    {
        PlayerPrefs.SetFloat("GameSoundsVolume", value);
        OnSaveSoundsVolumeSettings?.Invoke(value);
    }
}
