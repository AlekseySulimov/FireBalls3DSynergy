using System.Collections.Generic;
using Obstacles.Sequence;
using UnityEngine;

namespace Obstacles.Disappearing
{
	public class ObstacleDisappearing
	{
		private readonly Transform _obstacleRoot;
		private readonly IEnumerable<Obstacle> _obstacles;
	}
}