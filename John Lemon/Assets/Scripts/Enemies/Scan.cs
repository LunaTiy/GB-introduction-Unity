using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
	[SerializeField] private int _countRays = 3;
	[SerializeField] private float _angle = 30f;
	[SerializeField] private float _distance = 10f;
	[SerializeField] private Vector3 _offset;
	[Space]
	[SerializeField] private Transform _playerTransform;

	[HideInInspector] public bool isVisiblePlayer;
	[HideInInspector] public Vector3 playerPosition;

	void Update()
	{
		if (Vector3.Distance(transform.position, _playerTransform.position) < _distance)
		{
			RayToScan();

			//if (isVisiblePlayer)
			//{
			//	transform.position = Vector3.MoveTowards(transform.position, _playerPosition, 1f * Time.deltaTime);
			//}
		}
	}

	private void RayToScan()
	{
		isVisiblePlayer = false;

		if (_countRays == 1)
		{
			DrawRay(transform.forward);
		}
		else
		{
			float angleBetweenRays = _angle / (_countRays - 1);

			for (int i = 0; i < _countRays; i++)
			{
				float angleRay = transform.eulerAngles.y - _angle / 2 + i * angleBetweenRays;

				float directonX = Mathf.Sin(angleRay * Mathf.Deg2Rad);
				float directionZ = Mathf.Cos(angleRay * Mathf.Deg2Rad);

				Vector3 directionRay = new Vector3(directonX, 0, directionZ);

				DrawRay(directionRay);
			}
		}
	}

	private void DrawRay(Vector3 direction)
	{
		RaycastHit hit;
		Vector3 position = transform.position + _offset;
		
		if(Physics.Raycast(position, direction, out hit, _distance))
		{
			if (hit.transform.gameObject.tag == "Player")
			{
				Debug.DrawLine(position, hit.point, Color.green);
				playerPosition = hit.point;
				isVisiblePlayer = true;
			}
			else
			{
				Debug.DrawLine(position, hit.point, Color.blue);
			}
		}
		else
		{
			Debug.DrawRay(position, direction * _distance, Color.red);
		}
	}
}
