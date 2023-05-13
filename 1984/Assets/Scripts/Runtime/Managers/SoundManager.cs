using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioMixer audioMixer;

    public AudioSource bgmSource;
    public AudioSource effectSource;

    public AudioClip bgmClip;
    public AudioClip[] effectClips;

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
    }

    private void Start()
    {
        bgmSource.clip = bgmClip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayEffect(int index)
    {
        effectSource.clip = effectClips[index];
        effectSource.Play();
    }

    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGMVolume", volume);
    }

    public void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat("EffectVolume", volume);
    }
}