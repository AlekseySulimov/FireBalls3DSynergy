using System.Threading.Tasks;
using Obstacles;
using Obstacles.Disappearing;
using Towers.Generation.Disassembling;
using UnityEngine;

namespace Paths.Builders
{
	public class PathPlatformBuilder : MonoBehaviour
	{
		[SerializeField] private PathTowerBuilder _towerBuilder;
		[SerializeField] private PathObstacleBuilder _obstacleBuilder;
		private ObstacleCollisionFeedback _obstacleCollisionFeedback;
		public void Initialize(PathPlatformStructure pathPlatformStructure, ObstacleCollisionFeedback collisionFeedback)
		{
			_towerBuilder.Initialize(pathPlatformStructure.TowerStructure);
			_obstacleBuilder.Initialize(pathPlatformStructure.Obstacles);

			_obstacleCollisionFeedback = collisionFeedback;
		}

		public async Task<(TowerDisassembling, ObstacleDisappearing)> BuildAsync()
		{
			TowerDisassembling disassembling =
				await _towerBuilder.BuildAsync(_obstacleCollisionFeedback.PlayerProjectilePool);
			ObstacleDisappearing disappearing = _obstacleBuilder.Build(_obstacleCollisionFeedback);

			return (disassembling, disappearing);
		}
	}
}