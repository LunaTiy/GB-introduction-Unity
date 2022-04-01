using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDamagePlayer : MonoBehaviour
{
	public SoloSpawnerGhost spawner;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			PlayerLogic player = other.gameObject.GetComponent<PlayerMono>().player;
			player.LoseHealth();

			spawner.isLiveGhost = false;
			Destroy(gameObject);
		}
	}
}
