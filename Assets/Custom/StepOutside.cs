using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StepOutside : MonoBehaviour
{
    [SerializeField] private AudioMixerSnapshot outside;

    private void OnTriggerEnter(Collider other)
    {
        outside.TransitionTo(0.5f);
    }
}
