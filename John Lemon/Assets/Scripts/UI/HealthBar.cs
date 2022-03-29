using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Sprite _spriteEmptyHealth;
	[SerializeField] private Sprite _spriteFullHealth;
	[Space]
	[SerializeField] private PlayerMono _playerMono;

	private PlayerLogic _playerLogic;

	private void Start()
	{
		_playerLogic = _playerMono.player;

		DrawHealthBar();
		_playerLogic.eventUpdateUI += DrawHealthBar;
	}

	private void DrawHealthBar()
	{
		for (int i = 0; i < _playerLogic.Health; i++)
		{
			Image image = transform.GetChild(i).GetComponent<Image>();
			image.sprite = _spriteFullHealth;
		}

		for(int i = _playerLogic.Health; i < _playerLogic.maxHealth; i++)
		{
			Image image = transform.GetChild(i).GetComponent<Image>();
			image.sprite = _spriteEmptyHealth;
		}
	}
}
