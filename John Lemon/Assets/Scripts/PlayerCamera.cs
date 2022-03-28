using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _angularSpeed;
    [Space]
    [SerializeField] private Transform _target;
	[SerializeField] private LayerMask _masks;

	private Vector3 _fixedLocalPosition;

	private void Start()
	{
		_fixedLocalPosition = _target.InverseTransformPoint(transform.position);
	}

	private void FixedUpdate()
	{
		FollowTarget();
		LookToTarget();
		CheckObstacles();
	}

	private void FollowTarget()
	{
		Vector3 currentPosition = _target.TransformPoint(_fixedLocalPosition);
		transform.position = Vector3.Lerp(transform.position, currentPosition, _movementSpeed * Time.fixedDeltaTime);
	}

	private void LookToTarget()
	{
		Quaternion _currentRotation = Quaternion.LookRotation(_target.position - transform.position);
		transform.rotation = Quaternion.Lerp(transform.rotation, _currentRotation, _angularSpeed * Time.fixedDeltaTime);
	}

	private void CheckObstacles()
	{
		RaycastHit raycastHit;
		
		if(Physics.Raycast(_target.position, transform.position - _target.position, out raycastHit,
			Vector3.Distance(transform.position, _target.position), _masks))
		{
			transform.position = raycastHit.point;
			transform.LookAt(_target.position);
		}
	}
}
