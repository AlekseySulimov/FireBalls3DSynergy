using Factory;
using UnityEngine;

namespace Shooting.Pool
{
	[CreateAssetMenu(fileName = "ProjectileFactory", menuName = "ScriptableObjects/Shooting/ProjectileFactory", order = 0)]
	public class ProjectileFactorySo : ScriptableObject, IFactory<Projectile>
	{
		[SerializeField] private Projectile _projectilePrefab;
		
		public Projectile Create()
		{
			return Instantiate(_projectilePrefab);
		}
	}
}