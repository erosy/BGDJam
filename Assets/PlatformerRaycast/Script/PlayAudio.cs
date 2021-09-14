using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySimpleAudio()
    {
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
