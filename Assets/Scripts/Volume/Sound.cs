using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string audioClipName;
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitchAudioClip;
     
    [HideInInspector]
    public AudioSource source;
    public bool loop = false;
    public AudioMixerGroup audioMixerGroup;
}
