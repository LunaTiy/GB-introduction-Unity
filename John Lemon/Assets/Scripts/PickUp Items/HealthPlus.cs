using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlus : MonoBehaviour
{
	[SerializeField] private PlayerMono _playerMono;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && _playerMono.player.IsTakeHealth())
		{
			Destroy(gameObject);
		}
	}
}
