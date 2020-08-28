using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StepInside : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot inside;

    private void OnTriggerEnter(Collider other)
    {
        inside.TransitionTo(0.5f);
    }
}
