using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;
	public static AudioManager manager;
	public AudioMixerGroup outputAudioMixerGroup;

	public Sound[] sounds;
	
	
		void Start()
	    {
            AudioManager.manager.Play("MainTheme");
            AudioManager.manager.Play("Espace");
        }

	private void Awake()
    {
        // manager is a singleton. 
        if (AudioManager.manager == null)
        {
            AudioManager.manager = this;
        } else
        {
            Destroy(this);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
			s.source.outputAudioMixerGroup = s.outputAudioMixerGroup;
        }
    }


	private void Update()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
			s.source.spatialBlend = s.spatialBlend;
        }
    }



	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
		s.source.spatialBlend =0f;
		

		s.source.Play();

	
	}


	public void Stop(string name)
    {
        // Search for the requested sound
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // Check if the sound was not found
        if (s == null)
 {
            Debug.Log(string.Format("Not found: '{0}'", name));

            return;
        }

        // Stop the sound
        s.source.Stop();
    }

}
