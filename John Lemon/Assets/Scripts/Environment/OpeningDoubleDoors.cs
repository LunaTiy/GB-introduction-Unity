using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoubleDoors : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		PlayerLogic player = other.gameObject.GetComponent<PlayerMono>().player;

		if (gameObject.tag == "SilverKey" && player.IsUseItem(InventoryItems.SilverKey) ||
			gameObject.tag == "GoldKey" && player.IsUseItem(InventoryItems.GoldKey))
		{
			transform.GetComponent<BoxCollider>().enabled = false;
			transform.GetChild(0).GetComponent<Animator>().SetTrigger("Open");
			transform.GetChild(1).GetComponent<Animator>().SetTrigger("Open");
		}
	}
}
