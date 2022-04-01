using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;
	private bool _isOpenInventory;

	private void Start()
	{
		_inventoryPanel.SetActive(_isOpenInventory);
	}

	public void OnClickButton()
	{
		_isOpenInventory = !_isOpenInventory;
		_inventoryPanel.SetActive(_isOpenInventory);
	}
}
