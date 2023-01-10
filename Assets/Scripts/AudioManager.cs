using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Awake()
    {
        foreach (var sound in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.volume = sound.volume;
            source.pitch = sound.pitch;
            source.loop = sound.loop;
            source.clip = sound.AudioClip;
            sound.audioSource = source;
        }
    }

    public void playMySound(string name)
    {
        foreach (var sound in sounds)
        {
            if (sound.name == name)
            {
                sound.audioSource.Play();
            }
        }
    }
}
