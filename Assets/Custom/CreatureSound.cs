using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CreatureSound : MonoBehaviour
{
    [SerializeField] private float delay = 0.3f;

    private float clock = 0f;
    public AudioSource[] source;
    private byte nextIndex = 0;

    
    void Start()
    {
        source = new AudioSource[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            source[i] = transform.GetChild(i).GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        clock += Time.deltaTime;
        if (clock > delay)
        {
            if(nextIndex >= source.Length) { nextIndex = 0; }

            if (source[nextIndex] != null) { source[nextIndex].Play(); }
            nextIndex++;
            clock = 0;
        }
    }
}
