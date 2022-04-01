using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingItem : MonoBehaviour
{

	[SerializeField] private float _duration;

	private void Update()
	{
		float angleRotation = 360 / _duration * Time.deltaTime;
		transform.Rotate(new Vector3(transform.rotation.x, angleRotation, transform.rotation.z));
	}
}
