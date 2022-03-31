using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWalking : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _angularSpeed;
	[SerializeField] private float _durationLooking;
    [Space]
    [SerializeField] private Transform _path;

	private Animator _animator;
	private Scan _scan;

	private List<Transform> _pointsPath;
	private Vector3 _targetPosition;
	private int _indexTargetPoint;

	private Vector3 _prevPosition;
	private float _currentDurationLooking;
	private bool _isLooking;
	private bool _isLookingPlayer;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_scan = GetComponent<Scan>();

		_pointsPath = new List<Transform>();
		SetPointsFromPath();

		_indexTargetPoint = 0;
		_targetPosition = _pointsPath[_indexTargetPoint].position;
		_prevPosition = _targetPosition;

		_isLooking = true;
	}

	private void Update()
	{
		Movement();
		Looking();
	}

	private void Movement()
	{
		if (_scan.isVisiblePlayer)
		{
			transform.position = Vector3.MoveTowards(transform.position, _scan.playerPosition, _movementSpeed * Time.deltaTime);
		}
		else
		{
			if (!_isLooking)
			{
				if (_targetPosition == transform.position)
				{
					SavePositionForLooking();
					SavePositionForMovement();
					_isLooking = true;
					_animator.SetBool("Walk", false);
				}

				_animator.SetBool("Walk", true);
				transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);
			}
		}
	}

	private void Looking()
	{
		if (_isLooking)
		{
			_currentDurationLooking += Time.deltaTime;

			if (_currentDurationLooking < _durationLooking)
			{
				Quaternion targetRotation = Quaternion.LookRotation(_prevPosition - transform.position);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _angularSpeed * Time.deltaTime);
			}
			else
			{
				Vector3 directionVector = _targetPosition - transform.position;

				Quaternion targetRotation = Quaternion.LookRotation(directionVector);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _angularSpeed * Time.deltaTime);

				if (Vector3.Angle(transform.forward, directionVector) < 5f)
				{
					_currentDurationLooking = 0f;
					_isLooking = false;
				}
			}
		}
	}

	private void SavePositionForLooking()
	{
		int indexPointForLooking = _indexTargetPoint - 1;
		if (indexPointForLooking < 0) indexPointForLooking = _pointsPath.Count - 1;
		_prevPosition = _pointsPath[indexPointForLooking].position;
	}

	private void SavePositionForMovement()
	{
		_indexTargetPoint++;
		if (_indexTargetPoint == _pointsPath.Count) _indexTargetPoint = 0;
		_targetPosition = _pointsPath[_indexTargetPoint].position;
	}

	private void SetPointsFromPath()
	{
		for (int i = 0; i < _path.childCount; i++) {
			Transform point = _path.GetChild(i);
			_pointsPath.Add(point);
		}
	}
}
