using System;
using Characters;
using Paths;
using Pool;
using Shooting;
using Shooting.Pool;
using UnityEngine;
using UnityEngine.Serialization;
using Characters;

namespace PlayerComponents
{
	public class Player : MonoBehaviour
	{
		[Header("Character")]
		[SerializeField] private CharacterContainerSo _characterContainer;
		
		[Header("Path")]
		[SerializeField] private MovePreferencesSo _movePreferences;
		[SerializeField] private Path _path;
		
		[Header("Shooting")]
		[SerializeField] private ShootingPreferencesSo _shootingPreferences;
		
		[SerializeField] private ProjectilePool _projectilePool;
		
		private Weapon _weapon;
		private FireRate _fireRate;
		private PathFollowing _pathFollowing;
		
		private void Start()
		{
			Character character = _characterContainer.Create(transform);
			
			_projectilePool.Initialize(_shootingPreferences.ProjectileFactory);
			_projectilePool.Prewarm();

			_weapon = new Weapon(character.ShootPoint, _projectilePool, _shootingPreferences.ProjectileSpeed);
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