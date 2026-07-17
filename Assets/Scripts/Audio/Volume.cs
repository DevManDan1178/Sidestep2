using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioMixer audioMixer;

    public static float audioVolume;

    public Slider slider;

    void Start()
    {
        slider.value = audioVolume;
    }
    void OnEnable() 
    {
        slider.value = audioVolume;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

        audioVolume = volume;
    }

}
