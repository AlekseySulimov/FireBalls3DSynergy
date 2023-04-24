using UnityEngine;

namespace Shooting
{
	public class FireRate
	{
		private readonly float _value;
		private readonly Weapon _weapon;
		
		private  float _lastShootTime;

		public FireRate(float value, Weapon weapon)
		{
			_value = value;
			_weapon = weapon;
		}

		private bool CanShoot => Time.time >= _lastShootTime + 1.0f / _value;

		public void Shoot()
		{
			if (CanShoot == false)
				return;
			
			_weapon.Shoot();
			_lastShootTime = Time.time;
		}
	}
}