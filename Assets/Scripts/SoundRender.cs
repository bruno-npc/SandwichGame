using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRender : MonoBehaviour
{
    public List<AudioClip> audioAdd;

    public List<AudioClip> audioTheme;

    public AudioClip audioRemove;

    private AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void ThemePlay (){
        var audioClip = audioTheme[Random.Range(0, audioTheme.Count)];
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public void SpawnNewIngredient (){
        var audioClip = audioAdd[Random.Range(0, audioAdd.Count)];
        audioSource.PlayOneShot(audioClip);
    }

    public void RemoveIngredient(){
         audioSource.PlayOneShot(audioRemove);
    }
}
