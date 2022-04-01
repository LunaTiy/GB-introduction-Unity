using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			PlayerLogic player = other.gameObject.GetComponent<PlayerMono>().player;

			if(gameObject.tag == "GoldKey" && player.IsPickupItem(InventoryItems.GoldKey) || 
				gameObject.tag == "SilverKey" && player.IsPickupItem(InventoryItems.SilverKey))
			{
				Destroy(gameObject);
			}
		}
	}
}
