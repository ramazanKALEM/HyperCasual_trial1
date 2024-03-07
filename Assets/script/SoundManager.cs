using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;
    public bool sound;

    void Start()
    {
        
    }
    private void Awake()
    {
        MakeSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    void Update()
    {
        
    }
    public void  ONOF()
    {
        sound = !sound;
    }
    public void PlaySoundFx(AudioClip clip ,float volume)
    {
     if (sound)
        {
        audioSource.PlayOneShot(clip ,volume); 
        }
    }    




}
