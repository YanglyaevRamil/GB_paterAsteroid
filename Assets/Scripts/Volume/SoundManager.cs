using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[System.Serializable]
public class SoundManager : MonoBehaviour
{
    private SoundController soundController;
    private void Awake()
    {
        var soundControllerGO = new GameObject("SoundController");
        soundControllerGO.transform.SetParent(transform);
        soundController = soundControllerGO?.AddComponent<SoundController>();

        var volumeControllerGO = Instantiate(Resources.Load<GameObject>("Audio/Mixer/VolumeController"));
        volumeControllerGO.transform.SetParent(transform);
        var volumeController = volumeControllerGO.GetComponent<VolumeController>();
        volumeController.OnSaveMusicVolumeSettings += SaveMusicVolumeSettings;
        volumeController.OnSaveSoundsVolumeSettings += SaveSoundsVolumeSettings;

        soundController.PlayMusic(MusicEnum.UniverseMusic);
    }

    private void SaveSoundsVolumeSettings(float value)
    {
        soundController.SoundsVolumeChanged(value);
        soundController.PlaySound(SoundsEnum.PlayerHit);
    }

    private void SaveMusicVolumeSettings(float value)
    {
        soundController.MusicVolumeChanged(value);
    }

    public void OnClikButton()
    {
        Debug.Log("OnClikButton");
        soundController.PlaySound(SoundsEnum.ButtonClick);
    }
}
