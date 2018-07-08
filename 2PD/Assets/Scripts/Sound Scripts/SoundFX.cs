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
	public static string Music_Title = "Title";
	public static string SoundFx_Select = "Select";
	public static string SoundFx_Hover = "Hover";
	public static string SoundFx_ArrowShoot = "ArrowShoot";
	public static string SoundFx_SwordSwing = "SwordSwing";
	public static string SoundFx_SlimeAttacked = "SlimeAttacked";
	public static string SoundFx_SlimeDeath = "SlimeDeath";
	public static string SoundFx_ChestOpen = "ChestOpen";
	public static string SoundFx_SkillChange = "SkillChange";
	public static string SoundFx_Platform = "Platform";
	public static string SoundFx_BatAttacked = "BatAttacked";
	public static string SoundFx_BatDeath = "BatDeath";
}