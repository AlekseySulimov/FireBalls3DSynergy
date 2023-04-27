using System.Collections.Generic;
using System.Numerics;
using Obstacles.Sequence;
using UnityEngine;
using UnityObject = UnityEngine.Object;
using Vector3 = UnityEngine.Vector3;

namespace Obstacles.Generation
{
	public class ObstacleGeneration
	{
		private readonly IReadOnlyList<Obstacle> _obstaclesPrefabs;

		public ObstacleGeneration(IReadOnlyList<Obstacle> obstaclesPrefabs )
		{
			_obstaclesPrefabs = obstaclesPrefabs ;
		}

		public IEnumerable<Obstacle> Create(Transform root, ObstacleCollisionFeedback feedback)
		{
			var createdObstacles = new Obstacle[_obstaclesPrefabs.Count];
			
			for (var i = 0; i < _obstaclesPrefabs.Count; i++)
			{
				Obstacle createdObstacle = UnityObject.Instantiate(_obstaclesPrefabs[i], root);
				createdObstacle.Initialize(feedback);
				createdObstacle.transform.eulerAngles = GetRandomYRotation();
				createdObstacles[i] = createdObstacle;
			}
			return createdObstacles;
		}

		private Vector3 GetRandomYRotation()
		{
			return Vector3.up * Random.Range(0.0f, 360.0f);
		}
	}
}