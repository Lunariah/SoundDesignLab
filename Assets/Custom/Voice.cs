using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Voice : MonoBehaviour
{
    [SerializeField]
    private AudioClip ac_start;
    [SerializeField]
    private AudioClip ac_nohelp;
    [SerializeField]
    private AudioClip[] ac_capture;
    [SerializeField]
    [Tooltip("Wait before ac_nohelp is played")]
    private float patience;

    private AudioSource source;
    private AudioClip played_next;
    private byte captures = 0;
    private float timeSinceLastCapture = 0;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        // Check when to start being annoying
        timeSinceLastCapture += Time.deltaTime;
        if (timeSinceLastCapture > patience)
        {
            played_next = ac_nohelp;
            timeSinceLastCapture = Mathf.NegativeInfinity;
        }

        // Play next line in queue
        if (played_next != null && !source.isPlaying)
        {
            Debug.Log("Adding" + played_next.name + " to queue");
            source.clip = played_next;
            played_next = null;
            source.Play();
        }
    }

    public void OnGameStart() // Called by Menu UI > Button
    {
        played_next = ac_start;
        source.Play();
    }

    public void OnCollect() // Called by Interaction
    {
        timeSinceLastCapture = 0;
        played_next = ac_capture[captures++];
    }
}

// Time 0

// Every collect

// Specific collect

// Half collected

// Time passed since last collect

// Last collected