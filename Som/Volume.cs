using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    public AudioMixer mixAud;
    public void NivelVolume(float volume)
    {
        mixAud.SetFloat("volume", volume);
    }
}