using System.Collections.Generic;
using Obstacles;
using Obstacles.Generation;
using Obstacles.Sequence;
using PlayerComponents;
using Shooting.Pool;
using UnityEngine;

namespace Paths.Builders
{
	public class PathObstacleBuilder : MonoBehaviour
	{
		[SerializeField] private Transform _root;
		private IReadOnlyList<Obstacle> _obstaclesPrefabs;

		public void Initialize(IReadOnlyList<Obstacle> obstaclePrefabs)
		{
			_obstaclesPrefabs = obstaclePrefabs;
		}

		public void Build(ObstacleCollisionFeedback feedback)
		{
			ObstacleGeneration generation = new ObstacleGeneration(_obstaclesPrefabs);
			IEnumerable<Obstacle> obstacles = generation.Create(_root, feedback);
		}
	}
}