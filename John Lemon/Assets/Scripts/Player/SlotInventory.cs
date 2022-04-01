using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryItems
{
	Empty,
	GoldKey,
	SilverKey
}

public class SlotInventory
{
	public InventoryItems _item;

	public SlotInventory()
	{
		_item = InventoryItems.Empty;
	}

	public InventoryItems Item
	{
		get => _item;
		set => _item = value;
	}
}
