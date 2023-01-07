using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] clips;

    public AudioSource audioSource;
    public int clipIndex;

    public void MusicSwitch(int clipInt)
    {
        clipIndex = clipInt;
        audioSource.clip = clips[clipIndex];
        audioSource.Play();
    }
}
