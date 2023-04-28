using System.Threading;
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
		private CancellationTokenSource _cancellationTokenSource;
		public void Initialize(PathPlatformStructure pathPlatformStructure,
			ObstacleCollisionFeedback collisionFeedback,
			CancellationTokenSource cancellationTokenSource)
		{
			_towerBuilder.Initialize(pathPlatformStructure.TowerStructure);
			_obstacleBuilder.Initialize(pathPlatformStructure.Obstacles);

			_obstacleCollisionFeedback = collisionFeedback;
			_cancellationTokenSource = cancellationTokenSource;
		}

		public async Task<(TowerDisassembling, ObstacleDisappearing)> BuildAsync()
		{
			TowerDisassembling disassembling =
				await _towerBuilder.BuildAsync(_obstacleCollisionFeedback.PlayerProjectilePool,
					_cancellationTokenSource.Token);

			if (_cancellationTokenSource.IsCancellationRequested)
			{
				return (disassembling, null);
			}
			ObstacleDisappearing disappearing = _obstacleBuilder.Build(_obstacleCollisionFeedback);

			return (disassembling, disappearing);
		}
	}
}