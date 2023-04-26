using System.Collections.Generic;
using System.Threading.Tasks;
using Obstacles.Sequence;
using Tweening;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Obstacles.Disappearing
{
	public class ObstacleDisappearing
	{
		private readonly Transform _obstacleRoot;
		private readonly IEnumerable<Obstacle> _obstacles;
		private readonly IAwaitableTweenAnimation _animation;

		public ObstacleDisappearing(Transform obstacleRoot, IEnumerable<Obstacle> obstacles, IAwaitableTweenAnimation animation)
		{
			_obstacleRoot = obstacleRoot;
			_obstacles = obstacles;
			_animation = animation;
		}

		public async Task ApplyAsync()
		{
			await _animation.ApplyTo(_obstacleRoot);

			foreach (var obstacle in _obstacles)
			{
				UnityObject.Destroy(obstacle.gameObject);
			}

			await Task.CompletedTask;
		}
	}
}