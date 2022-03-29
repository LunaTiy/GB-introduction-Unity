using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private const float COMPENSATOR = 10f;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _angularSpeed;
	[SerializeField] private float _jumpForce;
	[Space]
	[SerializeField] private Animator _animator;

    private Rigidbody _rb;
	private CapsuleCollider _capsuleCollider;
	private Transform _childJohn;

	private bool _isGrounded;

	private void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_capsuleCollider = GetComponent<CapsuleCollider>();
	}

	private void Update()
	{
		IsGrounded();
		Jump();
	}

	private void FixedUpdate()
	{
		Movement();
	}

	private void Movement()
	{
		if (_isGrounded)
		{
			float mY = Input.GetAxis("Vertical");
			float mX = Input.GetAxis("Horizontal");

			if (mY < 0)
				mX = -mX;

			Vector3 movementDirection = transform.forward * mY * _movementSpeed * Time.fixedDeltaTime * COMPENSATOR;
			movementDirection.y = _rb.velocity.y;

			Vector3 rotateDirection = _rb.angularVelocity;
			rotateDirection.y = mX * _angularSpeed * Time.fixedDeltaTime * COMPENSATOR;

			_rb.velocity = movementDirection;
			_rb.angularVelocity = rotateDirection;

			AnimateMovement(mY);
		}
		else
		{
			_rb.angularVelocity = Vector3.zero;
		}
	}

	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
		{
			_rb.AddForce(Vector3.up * _jumpForce * COMPENSATOR);
		}
	}

	private void IsGrounded()
	{
		RaycastHit raycastHit;

		Vector3 centerDownSphere = transform.position + Vector3.up * _capsuleCollider.radius;
		Vector3 centerUpSphere = transform.position + Vector3.up * (_capsuleCollider.height - _capsuleCollider.radius);

		Physics.CapsuleCast(centerDownSphere, centerUpSphere, _capsuleCollider.radius, Vector3.down, out raycastHit, 0.1f);

		SetIsGround(raycastHit.transform && raycastHit.transform != transform);
	}

	private void SetIsGround(bool value)
	{
		_isGrounded = value;
	}

	private void AnimateMovement(float speed)
	{
		bool isWalk = speed == 0 ? false : true;
		_animator.SetBool("Walk", isWalk);

		_animator.gameObject.transform.position = transform.position;
	}
}
