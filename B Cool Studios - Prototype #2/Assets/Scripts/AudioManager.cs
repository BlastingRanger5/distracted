using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        //If there is no AudioManager, this becomes the audioManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            //If there is another audioManager in the scene it destroys this gameobject
            Destroy(gameObject);
            return;
        }

        //Doesn't destroy the AudioManager
        DontDestroyOnLoad(gameObject);

        //for each Sound element in the sounds list...
        foreach (Sounds s in sounds)
        {
            //Adds the audioclip to the source
            s.source = gameObject.AddComponent<AudioSource>();
            //Makes a clip of the sound for the same length of the original sound
            s.source.clip = s.clip;

            //Sets the volume to what the sounds volume is
            s.source.volume = s.volume;
            //Sets the pitch to what the sounds pitch is
            s.source.pitch = s.pitch;
            //Puts on or off the looping of the sound depending on its value in the sounds
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        //Find the sound in the sounds list
        Sounds s = Array.Find(sounds, sound => sound.name == name);

        //If there is no sound with that name...
        if (s == null)
        {
            //Tell the developer that the sound does not exist and return out of the script.
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        //Play the sound
        s.source.Play();
    }
}
