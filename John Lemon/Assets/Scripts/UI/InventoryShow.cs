using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryShow : MonoBehaviour
{
    [SerializeField] private PlayerMono _playerMono;
    [SerializeField] private Sprite _spriteEmpty;
    [SerializeField] private Sprite _spriteGoldKey;
    [SerializeField] private Sprite _spriteSilverKey;

    private PlayerLogic _playerLogic;
    private Inventory _inventory;

    private void Start()
    {
        _playerLogic = _playerMono.player;
        _inventory = _playerLogic.inventory;

        ShowInventory();
        _playerLogic.eventUpdateUI += ShowInventory;
    }

    private void ShowInventory()
	{
        for(int i = 0; i < _inventory.InventorySize; i++)
		{
            InventoryItems item = _inventory[i].Item;
            ShowItem(item, i);
		}
	}

    private void ShowItem(InventoryItems item, int num)
	{
        Image image = transform.GetChild(num).GetComponent<Image>();

		switch (item)
		{
            case InventoryItems.Empty:
                image.sprite = _spriteEmpty;
                break;
            case InventoryItems.GoldKey:
                image.sprite = _spriteGoldKey;
                break;
            case InventoryItems.SilverKey:
                image.sprite = _spriteSilverKey;
                break;
		}
	}
}
