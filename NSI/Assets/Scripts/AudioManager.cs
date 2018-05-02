using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audiomixer;

    public static AudioManager instance;

    public Sound[] sounds;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Makes the soundtrack continue regardless of the user changing between scenes
        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.loop = s.loop;

            if (s == null)
            {
                return;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    void Start()
    {
        //Plays the main theme when the script is called
        Play("MainTheme");
    }

    public void SetVolume(float volume)
    {
        //creates a slider for the MasterVolume volume setting
        audiomixer.SetFloat("MasterVolume", volume);
    }
}