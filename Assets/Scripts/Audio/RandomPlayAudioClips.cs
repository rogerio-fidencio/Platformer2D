using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlayAudioClips : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private List<AudioSource> audioSources;

    private int _index = 0;

    public void PlayRandom()
    {
        if (_index >= audioSources.Count) _index = 0;

        var audioSource = audioSources[_index];

        audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
        audioSource.Play();

        _index++;
    }
}
