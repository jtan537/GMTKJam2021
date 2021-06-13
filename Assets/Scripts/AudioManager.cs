using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("ready");
        // Singleton pattern

        if(instance == null){
            instance = this;
        }else if (instance != this){
            // A unique case where the Singleton exists but not in this scene
            if (instance.gameObject.scene.name == null){
                instance = this;
            }
            else{
                Destroy(this);
            }
        }
        
        //DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }            
        Debug.LogWarning("Playing " + name);

        s.source.Play();
        // Debug.Log("playing " + name);
    }
    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }
        s.source.Stop();
        // Debug.Log("playing " + name);
    }
}
