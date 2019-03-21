using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class AudioClip_Dir_Class
    {
        public string audioClipName;
        public AudioClip audioClipValue;
        public float audioClipVolume;
    } 
  
    public AudioClip_Dir_Class []audioList;

    private List<AudioSource> audioSources = new List<AudioSource>();
    
    private void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            audioSources.Add(gameObject.AddComponent<AudioSource>());
        }
    }

    public void playClip(String name)
    {
        for (var i = 0; i < audioList.Length; i++)
        {
            if (audioList[i].audioClipName == name)
            {
                var audioSource = FindFreeAudioSource();

                if (audioSource != null)
                {
                    audioSource.PlayOneShot(audioList[i].audioClipValue, audioList[i].audioClipVolume);
                }

                break;
            }
        }
    }

    private AudioSource FindFreeAudioSource()
    {
        for (var i = 0; i < 10; i++) {

            if (!audioSources[i].isPlaying)
            {
                Debug.Log("ASSIGNED TO " + i);
                return audioSources[i];
            }

        }
        return null;
    }
}
