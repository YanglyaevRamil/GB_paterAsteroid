using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    private GameObject[] soundsGameObject;
    private GameObject[] backgroundMusicGameObject;

    private AudioSource[] sounds;
    private AudioSource[] backgroundMusic;

    private int currentPlayingMusic;

    private float backgroundMusicVolume;
    private float soundsVolume;

    private void Awake()
    {
        backgroundMusicGameObject = Resources.LoadAll<GameObject>("Audio/MusicData");
        backgroundMusic = new AudioSource[backgroundMusicGameObject.Length];
        for (int i = 0; i < backgroundMusicGameObject.Length; i++)
        {
            backgroundMusic[i] = Instantiate(backgroundMusicGameObject[i]?.GetComponent<AudioSource>());
            backgroundMusic[i].transform.SetParent(transform);
            backgroundMusic[i].name = backgroundMusicGameObject[i].name;
        }
        soundsGameObject = Resources.LoadAll<GameObject>("Audio/SoundsData");
        sounds = new AudioSource[soundsGameObject.Length];
        for (int i = 0; i < soundsGameObject.Length; i++)
        {
            sounds[i] = Instantiate(soundsGameObject[i]?.GetComponent<AudioSource>());
            sounds[i].transform.SetParent(transform);
            sounds[i].name = soundsGameObject[i].name;
        }
    }

    private void OnEnable()
    {
        backgroundMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    
        soundsVolume = PlayerPrefs.GetFloat("GameSoundsVolume", 0.75f);
    
        SetAudioSources(sounds, soundsVolume);
        SetAudioSources(backgroundMusic, backgroundMusicVolume);
    }

    private void SetAudioSources(AudioSource[] sounds, float volume)
    {
        foreach (AudioSource audio in sounds)
        {
            audio.volume = volume;
        }
    }

    public void PlayMusic(MusicEnum name)
    {
        switch (name)
        {
            case MusicEnum.UniverseMusic:
                PlayMusic("0_UniverseMusic");
                break;
            case MusicEnum.BattleMusic:
                PlayMusic("1_BattleMusic");
                break;
            default:
                PlayMusic("0_UniverseMusic");
                break;
        }
    }

    private void PlayMusic(string name)
    {
        StopMusic();
        AudioSource s = Array.Find(backgroundMusic, sound => sound.name == name);
            if (s == null)
            {
                Debug.LogWarning("Music: " + name + " not found");
                return;
            }

        s.PlayDelayed(1f);
        currentPlayingMusic = Array.IndexOf(backgroundMusic, s, 0);
    }

    public void StopMusic()
    {
        backgroundMusic[currentPlayingMusic].Stop();
    }

    public string GetAudioName()
    {
        return backgroundMusic[currentPlayingMusic].name;
    }
    public void MusicVolumeChanged(float value)
    {
        backgroundMusicVolume = value;
        foreach (AudioSource music in backgroundMusic)
        {
            music.volume = backgroundMusicVolume;
        }
    }

    public void MusicVolumeChanged()
    {
        backgroundMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        foreach (AudioSource music in backgroundMusic)
        {
            music.volume = backgroundMusicVolume;
        }
    }

    public void SoundsVolumeChanged(float value)
    {
        soundsVolume = value;
        foreach (AudioSource sound in sounds)
        {
            sound.volume = soundsVolume;
        }
    }

    public void SoundsVolumeChanged()
    {
        soundsVolume = PlayerPrefs.GetFloat("GameSoundsVolume", 0.75f);
        foreach (AudioSource sound in sounds)
        {
            sound.volume = soundsVolume;
        }
    }

    public void PlaySound(SoundsEnum name)
    {
        switch (name)
        {
            case SoundsEnum.PlayerShot:
                PlaySound("0_PlayerShot");
                break;
            case SoundsEnum.PlayerHit:
                PlaySound("1_PlayerHit");
                break;
            case SoundsEnum.AsteroidDead:
                PlaySound("2_AsteroidDead");
                break;
            case SoundsEnum.ButtonClick:
                PlaySound("3_ButtonClick");
                break;
            default:
                PlaySound("0_PlayerShot");
                break;
        }
    }

    private void PlaySound(string name)
    {
        AudioSource s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.Play();
    }
}
