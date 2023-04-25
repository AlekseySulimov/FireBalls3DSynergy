using Shooting.Pool;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shooting
{
	[CreateAssetMenu(fileName = "ShootingPreferencesSo", menuName = "ScriptableObjects/Shooting/Preferences")]
	public class ShootingPreferencesSo : ScriptableObject
	{
		[FormerlySerializedAs("_projectile")]
		[Header("Projectile")]
		[SerializeField] private ProjectileFactorySo _projectileFactory;
		[SerializeField] [Min(0.0f)] private float _projectileSpeed;
		
		[SerializeField] [Min(0.0f)] private float _fireRate;

		public ProjectileFactorySo ProjectileFactory => _projectileFactory;

		public float ProjectileSpeed => _projectileSpeed;

		public float FireRate => _fireRate;
	}
}