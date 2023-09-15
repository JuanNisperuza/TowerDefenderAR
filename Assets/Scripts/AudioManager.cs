using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> tracks;

    private System.Random random;
    private static AudioSource audioSource;
    public AudioSource MusicSource;

    private void Start()
    {
        random = new System.Random();
        audioSource = GetComponent<AudioSource>();
        PlayRandomTrack();
    }

    private void Update()
    {
        if (!MusicSource.isPlaying)
        {
            PlayRandomTrack();
        }
    }

    public void PlayRandomTrack()
    {
        int randomIndex = random.Next(tracks.Count);
        AudioClip randomTrack = tracks[randomIndex];
        MusicSource.clip = randomTrack;
        MusicSource.Play();
    }

    public static void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
