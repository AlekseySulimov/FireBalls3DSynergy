using System.Collections.Generic;
using Obstacles;
using Obstacles.Disappearing;
using Obstacles.Generation;
using Obstacles.Sequence;
using PlayerComponents;
using Shooting.Pool;
using Tweening;
using UnityEngine;

namespace Paths.Builders
{
	public class PathObstacleBuilder : MonoBehaviour
	{
		[SerializeField] private Transform _root;
		[SerializeField] private LocalMoveTweenSo _disappearingAnimation;
		
		private IReadOnlyList<Obstacle> _obstaclesPrefabs;

		public void Initialize(IReadOnlyList<Obstacle> obstaclePrefabs)
		{
			_obstaclesPrefabs = obstaclePrefabs;
		}

		public ObstacleDisappearing Build(ObstacleCollisionFeedback feedback)
		{
			ObstacleGeneration generation = new ObstacleGeneration(_obstaclesPrefabs);
			IEnumerable<Obstacle> obstacles = generation.Create(_root, feedback);

			return new ObstacleDisappearing(_root, obstacles, _disappearingAnimation);
		}
	}
}