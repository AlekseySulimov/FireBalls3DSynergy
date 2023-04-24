using UnityEngine;
using UnityEngine.Serialization;

namespace Shooting
{
	[CreateAssetMenu(fileName = "ShootingPreferencesSo", menuName = "ScriptableObjects/Shooting/Preferences")]
	public class ShootingPreferencesSo : ScriptableObject
	{
		[FormerlySerializedAs("_projectile")]
		[Header("Projectile")]
		[SerializeField] private Projectile _projectilePrefab;
		[SerializeField] [Min(0.0f)] private float _projectileSpeed;
		
		[SerializeField] [Min(0.0f)] private float _fireRate;

		public Weapon CreateWeapon(Transform shootPoint)
		{
			return new Weapon(shootPoint, _projectilePrefab, _projectileSpeed);
		}
		
		public FireRate CreateFireRate()
		{
			return new FireRate(_fireRate);
		}
	}
}