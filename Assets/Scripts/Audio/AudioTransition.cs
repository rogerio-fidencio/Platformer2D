using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot snapshot;
    [SerializeField] float transitionTime = .1f;

    public void MakeTransition()
    {
        snapshot.TransitionTo(transitionTime);
    }
}
