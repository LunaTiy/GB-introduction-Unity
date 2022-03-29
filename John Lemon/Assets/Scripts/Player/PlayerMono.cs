using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMono : MonoBehaviour
{
	[HideInInspector] public PlayerLogic player;

	private void Awake()
	{
		player = new PlayerLogic();
	}

	
}
