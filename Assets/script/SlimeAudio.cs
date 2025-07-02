using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAudio : MonoBehaviour
{
    AudioSource slimeAudio;
    // Start is called before the first frame update
    void Start()
    {
        slimeAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AudioPlay()
    {
        slimeAudio.Play();
    }
}
