using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualSound : MonoBehaviour
{
    AudioSource[] sources;
    Text text;
    GameObject AudioCue;

    void Start()
    {

        text = FindObjectOfType<Text>();

        sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];

        AudioCue = text.transform.parent.gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioCue.SetActive(!AudioCue.activeInHierarchy);
        }

            // When a key is pressed list all the gameobjects that are playing an audio
            text.text = null;
        foreach (AudioSource audioSource in sources)
        {
            if (audioSource.isPlaying) { text.text = text.text + audioSource.clip.name + "\n"; }
        }


     
    }
}

