using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBox : MonoBehaviour
{
    public static SoundBox instance;
    AudioSource audioSource;
    private void Awake()
    {
        if (SoundBox.instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
            
        }
        
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot(NamesOfSound name)
    {
        audioSource.PlayOneShot(GetAudioClip(name));
    }
    public void PlayOneShot(string name)
    {
        audioSource.PlayOneShot(GetAudioClip(name));
    }
    public void StopAndPlayOneShot(string name)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(GetAudioClip(name));
    }
    public void PlayIfDontPlay(NamesOfSound name)
    {
       
        if (!audioSource.isPlaying) PlayOneShot(name);
    }
    public void PlayIfDontPlay(string name)
    {
        SetVolume(1f);
        if (!audioSource.isPlaying) PlayOneShot(name);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    AudioClip GetAudioClip(NamesOfSound name)
    {
        SetVolume(Kayit.GetSesAcik()? 0.5f:0);
        return Resources.Load<AudioClip>("Sounds/" + name.ToString());
    }
    AudioClip GetAudioClip(string name)
    {
        SetVolume(1f);

        return Resources.Load<AudioClip>("Sounds/" + name);
    }

    public bool IsPlaying() { return audioSource.isPlaying; }


}
