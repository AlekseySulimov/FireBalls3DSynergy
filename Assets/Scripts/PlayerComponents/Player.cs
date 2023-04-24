using System;
using Characters;
using Shooting;
using UnityEngine;

namespace PlayerComponents
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private Projectile _projectile;
		[SerializeField] private Character _character;
		[SerializeField] private float _projectileSpeed;
		[SerializeField] private float _rate;
		
		private Weapon _weapon;
		private FireRate _fireRate;

		private void Start()
		{
			_weapon = new Weapon(_character.ShootPoint, _projectile, _projectileSpeed);
			_fireRate = new FireRate(_rate, _weapon);
		}

		public void Shoot() =>
			_fireRate.Shoot();
	}
}