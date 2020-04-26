using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    public Sound[] sounds;

    void Awake() {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
                s.source.playOnAwake = false;
            }
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        s.source.Play();
    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Could not stop sound " + name + " because it could not be found.");
            return;
        }
        StartCoroutine(FadeSoundOut(s, 3.0f));
    }

    public static IEnumerator FadeSoundOut(Sound s, float fadeTime)
    {
        float startVolume = s.source.volume;

        while(s.source.volume > 0)
        {
            s.source.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        s.source.Stop();
        s.source.volume = startVolume;
    }
}
