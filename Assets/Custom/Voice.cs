using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Voice : MonoBehaviour
{
    [SerializeField]
    private AudioClip ac_start;
    [SerializeField]
    private AudioClip ac_normal_collect;
    [SerializeField]
    private AudioClip ac_special_collect;
    [SerializeField]
    private AudioClip ac_halfgame;
    [SerializeField]
    private AudioClip ac_nohelp;
    [SerializeField]
    private AudioClip ac_end;
    [SerializeField]
    [Tooltip("Wait before ac_nohelp is played")]
    private float patience;

    private AudioSource source;
    private AudioClip played_next;
    private byte capturesRemaining = 10;
    private float timeSinceLastCapture = 0;
    private bool ready = false;

    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = ac_start;
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
        if (played_next != null)
        {
            Debug.Log("Adding" + played_next.name + " to queue");
            source.clip = played_next;
            played_next = null;
            ready = true;
        }
        else if (ready && !source.isPlaying)
        {
            Debug.Log("Reading " + source.clip.name);
            source.Play();
            ready = false;
        }
    }

    public void OnGameStart() // Called by Menu UI > Button
    {
        source.Play();
    }

    public void OnCollect() // Called by Interaction
    {
        timeSinceLastCapture = 0;
        capturesRemaining--;
        switch(capturesRemaining)
        {
            case 0:
                played_next = ac_end;
                break;
            case 4:
                played_next = ac_special_collect;
                break;
            default:
                played_next = ac_normal_collect;
                break;
        }
    }
}

// Time 0

// Every collect

// Specific collect

// Half collected

// Time passed since last collect

// Last collected