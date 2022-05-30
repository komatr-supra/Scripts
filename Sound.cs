using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] sounds;
    int playingSoundIndex = -1;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }
    private void PlayRandomMusic()
    {
        audioSource.PlayOneShot(sounds[Random.Range(0, sounds.Length - 1)]);
    }
}
