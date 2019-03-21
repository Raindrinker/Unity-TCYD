using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioMixer mixer;
    private AudioMixerSnapshot occluded;
    private AudioMixerSnapshot nonoccluded;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mixer = audioSource.outputAudioMixerGroup.audioMixer;
        occluded = mixer.FindSnapshot("Occluded");
        nonoccluded = mixer.FindSnapshot("Nonoccluded");
    }

    public void setOccluded(bool occ)
    {
        Debug.Log("OCCLUDED " + occ);
        
        if (occ)
        {
            occluded.TransitionTo(0.2f);
          
        }
        else
        {
           
            nonoccluded.TransitionTo(0.5f);
        }
    }
}
