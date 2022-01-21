using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    public Sound[] sounds;
    public Sound[] backgroundMusic;

    private int currentPlayingMusic;
    private bool shouldPlayMusic = false;
    public static SoundManager Instance;

    private float backgroundMusicVolume;
    private float soundsVolume;

    void Start()
    {
        /*if (shouldPlayMusic == true)
        {
            PlayMusic("BattleMusic");
        }*/
        PlayMusic("BattleMusic");
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        backgroundMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        soundsVolume = PlayerPrefs.GetFloat("GameSoundsVolume", 0.75f);

        CreateAudioSources(sounds, soundsVolume);
        CreateAudioSources(backgroundMusic, backgroundMusicVolume);

    }


    void Update()
    {
        /*if (currentPlayingMusic != 999 && !backgroundMusic[currentPlayingMusic].source.isPlaying)
        {
            currentPlayingMusic++;
            if (currentPlayingMusic >= backgroundMusic.Length)
            {
                currentPlayingMusic = 0;
            }

            backgroundMusic[currentPlayingMusic].source.Play();
        }*/
    }

    private void CreateAudioSources(Sound[] sounds, float volume)
    {
        foreach (Sound audio in sounds)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.audioClip;
            audio.source.volume = audio.volume * volume;
            audio.source.pitch = audio.pitchAudioClip;
            audio.source.loop = audio.loop;
        }
    }

    public void PlayMusic(string name)
    {
        /*if (shouldPlayMusic == false)
        {
            shouldPlayMusic = true;*/
        /*currentPlayingMusic = UnityEngine.Random.Range(0, backgroundMusic.Length - 1);
        backgroundMusic[currentPlayingMusic].source.volume = backgroundMusic[0].volume * backgroundMusicVolume;
        backgroundMusic[currentPlayingMusic].source.Play();*/

        StopMusic();
        Sound s = Array.Find(backgroundMusic, sound => sound.audioClipName == name);
            if (s == null)
            {
                Debug.LogWarning("Music: " + name + " not found");
                return;
            }

        s.source.PlayDelayed(3f);
        currentPlayingMusic = Array.IndexOf(backgroundMusic, s, 0);

        
    }

    public void StopMusic()
    {
        if (shouldPlayMusic == true)
        {
            shouldPlayMusic = false;
            backgroundMusic[currentPlayingMusic].source.Stop();
            
            //currentPlayingMusic = 999;
            
        }
        /*
                Sound s = Array.Find(backgroundMusic, sound => sound.audioClipName == name);
                if (s == null)
                {
                    Debug.LogWarning("Music: " + name + " not found");
                    return;
                }

                s.source.Stop();*/

        backgroundMusic[currentPlayingMusic].source.Stop();

    }

    public string GetAudioName()
    {
        return backgroundMusic[currentPlayingMusic].audioClipName;
    }

    public void MusicVolumeChanged()
    {
        foreach (Sound music in backgroundMusic)
        {
            backgroundMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
            music.source.volume = backgroundMusic[currentPlayingMusic].volume * backgroundMusicVolume;
        }
    }

    public void SoundsVolumeChanged()
    {
        soundsVolume = PlayerPrefs.GetFloat("GameSoundsVolume", 0.75f);
        foreach (Sound sound in sounds)
        {
            sound.source.volume = sound.volume * soundsVolume;
        }

        sounds[0].source.Play();
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.audioClipName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }
}
