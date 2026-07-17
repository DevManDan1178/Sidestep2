using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public bool audioPaused = false;

    public AudioMixerGroup volumeMixer;

    public bool loopLevelAudio = false;
    [HideInInspector]
    public AudioSource levelAudio;

    //initialization
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            if (s.name == "LevelAudio")
            {
            levelAudio = s.source;
            }
            for(int i = 0; i < sounds.Length; i++)
        {
             s.source.outputAudioMixerGroup = volumeMixer;
        }
        }

    }

    public void Play (string name)
    {   
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        s.source.Play();
        
        if (loopLevelAudio == true)
        {
            Sound levelAudioSound = Array.Find(sounds, sound => sound.name == "LevelAudio");
            levelAudioSound.source.loop = true;
        }
        
    }

    void Update()
    {
        if(PauseMenu.GameIsPaused == true)
        {
            foreach (Sound s in sounds)
            {
                s.source.Pause();
                audioPaused = true;
            }
        }
        else
        {
            if(audioPaused == true && PauseMenu.GameIsPaused == false)
            {
                foreach (Sound s in sounds)
                {
                s.source.UnPause();   
                }   
                audioPaused = false;

                
            }
        }

    }
}
