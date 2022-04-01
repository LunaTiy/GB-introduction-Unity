using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
	private SlotInventory[] _slots;
	private int _inventorySize = 5;

	public Inventory()
	{
		_slots = new SlotInventory[_inventorySize];

		for(int i = 0; i < _slots.Length; i++)
			_slots[i] = new SlotInventory();
	}

	public int InventorySize { get => _inventorySize; }

	public SlotInventory this[int num]
	{
		get
		{
			if (num >= _inventorySize) return null;

			return _slots[num];
		}
	}

	public bool IsAddItem(InventoryItems item)
	{
		for(int i = 0; i < _inventorySize; i++)
		{
			if (_slots[i].Item == InventoryItems.Empty)
			{
				_slots[i].Item = item;
				return true;
			}
		}

		return false;
	}

	public bool IsUseItem(InventoryItems item)
	{
		for (int i = 0; i < _inventorySize; i++)
		{
			if (_slots[i].Item == item)
			{
				_slots[i].Item = InventoryItems.Empty;
				return true;
			}
		}

		return false;
	}
}
