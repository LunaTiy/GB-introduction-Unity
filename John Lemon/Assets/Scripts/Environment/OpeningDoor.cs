using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			PlayerLogic player = collision.gameObject.GetComponent<PlayerMono>().player;

			if(gameObject.tag == "SilverKey" && player.IsUseItem(InventoryItems.SilverKey) || 
				gameObject.tag == "GoldKey" && player.IsUseItem(InventoryItems.GoldKey))
			{
				gameObject.GetComponent<Animator>().SetTrigger("Open");
			}
		}
	}
}
