using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioMixer audioMixer;

    public AudioSource bgmSource;
    public AudioSource effectSource;

    public AudioClip bgmClip;
    
    private Dictionary<string, AudioClip> _effectClips = new Dictionary<string, AudioClip>();
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        EffectClipsLoad();
    }

    private void Start()
    {
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play(); //temp
    }

    public void PlayEffect(string effectClipName)
    {
        if (_effectClips.ContainsKey(effectClipName))
        {
            var effectClip = _effectClips[effectClipName];
            effectSource.PlayOneShot(effectClip);
        }
        else
        {
            Debug.LogError($"EffectClipName: {effectClipName} is not exist");
        }
    }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("EffectVolume", volume);
    }

    private void EffectClipsLoad()
    {
        var sfxList = Resources.LoadAll<AudioClip>("Sounds/SFX/");
        
        foreach (var sfx in sfxList)
        {
            Debug.Log(sfx.name);
            _effectClips.Add(sfx.name, sfx);
        }
    }
}