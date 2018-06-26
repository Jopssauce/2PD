using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundFX
{

	public string name;
	public AudioClip SoundEffect;

	[HideInInspector]
	public AudioSource Source;

	public bool Loop;

	[Range(0.0f, 1.0f)]
	public float Volume;
}

public class MusicStrings
{
	public static string Music_BGM = "BGM";
	public static string SoundFx_Select = "Select";
	public static string SoundFx_Hover = "Hover";
}