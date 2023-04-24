using System;
using Characters;
using Shooting;
using UnityEngine;

namespace PlayerComponents
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private Character _character;
		[SerializeField] private ShootingPreferencesSo _shootingPreferences;
		
		private Weapon _weapon;
		private FireRate _fireRate;

		private void Start()
		{
			_weapon = _shootingPreferences.CreateWeapon(_character.ShootPoint);
			_fireRate = _shootingPreferences.CreateFireRate();
		}

		public void Shoot() =>
			_fireRate.Shoot(_weapon);
	}
}