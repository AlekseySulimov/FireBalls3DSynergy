using System;
using UnityEngine;

namespace Shooting.Pool
{
	public class RestoreProjectilePoolTrigger : MonoBehaviour
	{
		public event Action ProjectileReturned;
		
		//problem to work without DI container's. 
		//Because we create Towers on fly we cant apply dependencies.
		//In that case we cant apply ProjectPool to RestoreProjectilePoolTrigger.
		//If we have DI we could inject pool in that trigger and all will be fine.
		//But I dont understand why it 
		private ProjectilePool _pool;

		 public void Initialize(ProjectilePool pool)
		 {
			 _pool = pool;
		 }

		 private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Projectile projectile) == false)
				return;
			
			_pool.Return(projectile);
			ProjectileReturned?.Invoke();
		}
	}
}