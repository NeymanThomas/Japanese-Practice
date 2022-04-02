/// <summary>
/// The SoundManager is a singleton that is loaded at the start of the application
/// and controls all of the sounds that the application uses. The sound manager
/// is not destroyed upon loading in new scenes to help speed up performance.
/// </summary>

using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public Sound[] sounds;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeAudioVolume(float newVolume) {
        foreach (Sound s in sounds) {
            s.source.volume = newVolume;
        }
    }


    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.Log(s.name + " was not found. Did you mispell the name of the sound clip?");
            return;
        }
        s.source.PlayOneShot(s.clip);
    }
}
