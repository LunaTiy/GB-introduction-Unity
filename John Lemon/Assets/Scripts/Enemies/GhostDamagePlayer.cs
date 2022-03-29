using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamagePlayer : MonoBehaviour
{
	private PlayerLogic _player;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			_player = other.gameObject.GetComponent<PlayerMono>().player;
			_player.LoseHealth();
		}
	}
}
