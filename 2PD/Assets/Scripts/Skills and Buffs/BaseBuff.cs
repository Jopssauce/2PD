using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseBuff : MonoBehaviour 
{
	public enum BuffType
	{
		standard,
		infuse,
		damageOvertime
	}
	public string ID;
	public Sprite sprite;
	public ParticleSystem particle;
	GameObject tempParticle;
	public BuffType buffType;
	public BuffReceiver receiver;
	public bool isActivated = false;
	public float duration = 1;
	public UnityEvent EventOnActivate;
	public UnityEvent EventOnActivated;
	public UnityEvent EventOnDeactivated;
	public Color32 color;
	public virtual void Start()
	{
		receiver = GetComponent<BuffReceiver>();
	}
	public virtual void Activate(BuffReceiver receiver) 
	{ 
		isActivated = !isActivated;
		if(particle != null)
		{
			tempParticle = Instantiate(particle.gameObject, receiver.transform);
			tempParticle.transform.localPosition = Vector3.zero;
		} 
		EventOnActivated.Invoke(); 
	}

	public virtual void Deactivate(BuffReceiver receiver) 
	{ 
		isActivated = false;
		Destroy(tempParticle);
		EventOnDeactivated.Invoke(); 
	}


}
