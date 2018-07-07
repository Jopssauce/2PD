using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
	
	public SoundFX[] Sounds;
	public SoundFX[] Music;
	// Use this for initialization
	void Awake () 
	{
		foreach (SoundFX s in Sounds)
		{
			s.Source = gameObject.AddComponent<AudioSource> ();
			s.Source.clip = s.SoundEffect;
			s.Source.loop = s.Loop;
			s.Source.volume = s.Volume;
		}

		foreach (SoundFX s in Music)
		{
			s.Source = gameObject.AddComponent<AudioSource> ();
			s.Source.clip = s.SoundEffect;
			s.Source.loop = s.Loop;
			s.Source.volume = s.Volume;
		}
	}

	void Start()
	{
		PlayMusic (MusicStrings.Music_BGM);
	}

	public void Play (string name)
	{
		SoundFX s = Array.Find (Sounds, sound => sound.name == name);
		s.Source.Play();
	}

	public void PlayMusic(string name)
	{
		SoundFX s = Array.Find (Music, sound => sound.name == name);
		s.Source.Play();
	}

	public void PauseMusic(string name)
	{
		SoundFX s = Array.Find (Music, sound => sound.name == name);
		s.Source.Pause();
	}

	public void StopMusic(string name)
	{
		SoundFX s = Array.Find (Music, sound => sound.name == name);
		s.Source.Stop();
	}
}
