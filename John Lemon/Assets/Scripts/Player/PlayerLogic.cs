using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void UpdateUI();

public class PlayerLogic
{
	public event UpdateUI eventUpdateUI;

	public readonly int maxHealth = 5;
	public readonly int maxBomb = 5;

	public Inventory inventory;

	private int _health;
	private int _countBomb;

	public PlayerLogic()
	{
		inventory = new Inventory();

		_health = 3;
		_countBomb = 3;
	}

	public int Health { get => _health; }

	public int CountBomb { get => _countBomb; }

	public bool IsTakeHealth()
	{
		if (_health == maxHealth) return false;

		_health++;
		eventUpdateUI?.Invoke();
		return true;
	}

	public void LoseHealth()
	{
		_health--;

		if (_health < 0) _health = 0;

		eventUpdateUI?.Invoke();
	}

	public bool IsTakeBomb()
	{
		if (_countBomb == maxBomb) return false;

		_countBomb++;

		eventUpdateUI?.Invoke();
		return true;
	}

	public bool IsThrowBomb()
	{
		if (_countBomb <= 0) return false;

		_countBomb--;
		eventUpdateUI?.Invoke();
		return true;
	}

	public bool IsPickupItem(InventoryItems item)
	{
		bool isAdded = inventory.IsAddItem(item);

		if (isAdded)
			eventUpdateUI?.Invoke();

		return isAdded;
	}

	public bool IsUseItem(InventoryItems item)
	{
		bool isUsed = inventory.IsUseItem(item);

		if (isUsed)
			eventUpdateUI?.Invoke();

		return isUsed;
	}
}
