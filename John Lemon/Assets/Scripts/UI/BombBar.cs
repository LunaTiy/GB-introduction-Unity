using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombBar : MonoBehaviour
{
    [SerializeField] private Sprite _spriteEmptyBomb;
    [SerializeField] private Sprite _spriteFullBomb;
	[Space]
	[SerializeField] private PlayerMono _playerMono;

	private PlayerLogic _playerLogic;

	private void Start()
	{
		_playerLogic = _playerMono.player;

		DrawBombBar();
		_playerLogic.eventUpdateUI += DrawBombBar;
	}

	private void DrawBombBar()
	{
		for(int i = _playerLogic.maxBomb - 1; i >= _playerLogic.maxBomb - _playerLogic.CountBomb; i--)
		{
			Image image = transform.GetChild(i).GetComponent<Image>();
			image.sprite = _spriteFullBomb;
		}

		for(int i = _playerLogic.maxBomb - _playerLogic.CountBomb - 1; i >= 0; i--)
		{
			Image image = transform.GetChild(i).GetComponent<Image>();
			image.sprite = _spriteEmptyBomb;
		}
	}
}
