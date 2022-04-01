using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoloSpawnerGhost : MonoBehaviour
{
	[HideInInspector] public bool isLiveGhost;

	[SerializeField] private GameObject _prefab;
    [SerializeField] private float _respawnTime = 5f;
	[Space]
	[SerializeField] private Transform _path;
	[SerializeField] private Transform _playerTransform;
	[SerializeField] private Transform _enemies;

	private float _elapsedTime;

	private void Start()
	{
		GenerateGhost();
	}

	private void Update()
	{
		if (!isLiveGhost)
		{
			_elapsedTime += Time.deltaTime;

			if(_elapsedTime >= _respawnTime)
			{
				GenerateGhost();
				_elapsedTime = 0;
			}
		}
	}

	private void GenerateGhost()
	{
		GameObject ghost = Instantiate(_prefab, transform.position, Quaternion.identity, _enemies);

		ghost.GetComponent<GhostWalking>().path = _path;
		ghost.GetComponent<Scan>().playerTransform = _playerTransform;
		ghost.GetComponent<GhostDamagePlayer>().spawner = gameObject.GetComponent<SoloSpawnerGhost>();

		isLiveGhost = true;
	}
}
