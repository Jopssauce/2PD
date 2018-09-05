using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour 
{
}

public interface IUpgradeable<T>
{
	void Upgrade(T value);
}
