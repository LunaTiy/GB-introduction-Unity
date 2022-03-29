using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTiling : MonoBehaviour
{
	[SerializeField] private float _tilingX = 1f;
	[SerializeField] private float _tilingY = 1f;

	private Renderer _renderer;

	private void Start()
	{
		float scaleX = transform.localScale.x;
		float scaleY = transform.localScale.z;

		_renderer = GetComponent<Renderer>();

		_renderer.material.SetTextureScale("_MainTex", new Vector2(scaleX * _tilingX, scaleY * _tilingY));
	}
}
