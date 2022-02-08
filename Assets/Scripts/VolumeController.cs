using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private Slider musicVolumeSlider;

    [SerializeField]
    private Slider soundsVolumeSlider;

    

    public AudioMixer music;
    public AudioMixer sounds;

   

    private void Awake()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        soundsVolumeSlider.value = PlayerPrefs.GetFloat("GameSoundsVolume", 0.75f);
        
    }

   

    public void SaveMusicVolumeSettings()
    {
        float musicVolumeValue = musicVolumeSlider.value;
        music.SetFloat("MusicVol", Mathf.Log10(musicVolumeValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeValue);
        SoundManager.Instance.MusicVolumeChanged();

       
    }

    public void SaveSoundsVolumeSettings()
    {
        

        float soundsVolumeValue = soundsVolumeSlider.value;
        sounds.SetFloat("SoundVol", Mathf.Log10(soundsVolumeValue) * 20);
        PlayerPrefs.SetFloat("GameSoundsVolume", soundsVolumeValue);
        SoundManager.Instance.SoundsVolumeChanged();
    }

    
    
}
