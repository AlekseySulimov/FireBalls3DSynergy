using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Animations
{
	public class UIRotationAnimation : MonoBehaviour
	{
		[SerializeField] private float _speed;

		private void Update()
		{
			Rotate(_speed);
		}

		private void Rotate(float speed)
		{
			float angle = speed * Time.deltaTime;
			transform.Rotate(Vector3.forward, angle);
			
		}
		
	}
}