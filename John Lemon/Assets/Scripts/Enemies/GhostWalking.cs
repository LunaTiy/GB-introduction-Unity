using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWalking : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _angularSpeed;
    [Space]
    [SerializeField] private Transform _path;

	private List<Transform> _points;
	private Vector3 _currentPosition;
	private int _indexCurrentPoint;

	private void Start()
	{
		_points = new List<Transform>();
		SetPointsFromPath();

		_indexCurrentPoint = 0;
		_currentPosition = _points[_indexCurrentPoint].position;
	}

	private void Update()
	{
		Movement();
	}

	private void Movement()
	{
		if(_currentPosition == transform.position)
		{
			_indexCurrentPoint++;

			if (_indexCurrentPoint == _points.Count) _indexCurrentPoint = 0;

			_currentPosition = _points[_indexCurrentPoint].position;
		}

		Debug.Log("Ghost followed position:" + _currentPosition);
		transform.position = Vector3.MoveTowards(transform.position, _currentPosition, _movementSpeed * Time.deltaTime);
	}

	private void SetPointsFromPath()
	{
		for (int i = 0; i < _path.childCount; i++) {
			Transform point = _path.GetChild(i);
			_points.Add(point);
		}
	}
}
