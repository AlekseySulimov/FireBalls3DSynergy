using System;
using Characters;
using Paths;
using Pool;
using Shooting;
using Shooting.Pool;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerComponents
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private Character _character;
		[SerializeField] private ShootingPreferencesSo _shootingPreferences;
		[SerializeField] private ProjectilePool _projectilePool;
		
		
		[SerializeField] private Path _path;
		[SerializeField] private MovePreferencesSo _movePreferences;

		private Weapon _weapon;
		private FireRate _fireRate;
		private PathFollowing _pathFollowing;
		private void Start()
		{
			_projectilePool.Initialize(_shootingPreferences.ProjectileFactory);
			_projectilePool.Prewarm();

			_weapon = new Weapon(_character.ShootPoint, _projectilePool, _shootingPreferences.ProjectileSpeed);
			_fireRate = new FireRate(_shootingPreferences.FireRate);
			_pathFollowing = new PathFollowing(_path, this, _movePreferences);
		}

		public void Shoot() =>
			_fireRate.Shoot(_weapon);

		[ContextMenu(nameof(Move))]
		public void Move()
		{
			_pathFollowing.MoveToNext();
		}
	}
}