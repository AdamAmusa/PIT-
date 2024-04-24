using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] public AudioSource FX;
    [SerializeField] public AudioSource Music;


    [Header("Audio Clips")]
    public AudioClip punch;

    public AudioClip background;
    public AudioClip damage;

    private void Start(){
       
        
    }


    public void playPunch(){
        FX.PlayOneShot(punch);    
    }

    public void playPunchLand(){
        FX.PlayOneShot(damage);
    }

}
