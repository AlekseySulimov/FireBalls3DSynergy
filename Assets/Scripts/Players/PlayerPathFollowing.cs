using System.Collections.Generic;
using System.Threading;
using Obstacles.Disappearing;
using Paths;
using Towers.Generation.Disassembling;

namespace Players
{
	public class PlayerPathFollowing
	{
		private readonly PathFollowing _pathFollowing;
		private readonly Path _path;
		private readonly PlayerInputHandler _inputHandler;

		public PlayerPathFollowing(PathFollowing pathFollowing, Path path, PlayerInputHandler inputHandler)
		{
			_pathFollowing = pathFollowing;
			_path = path;
			_inputHandler = inputHandler;
		}

		public async void StartMovingAsync(CancellationToken cancellationToken)
		{
			IReadOnlyList<PathSegment> segments = _path.Segments;

			foreach (var pathSegment in segments)
			{
				_inputHandler.Disable();
				await _pathFollowing.MoveToNextAsync();
				
				(TowerDisassembling towerDisassembling, ObstacleDisappearing obstacleDisappearing) 
					= await pathSegment.PlatformBuilder.BuildAsync();

				if (cancellationToken.IsCancellationRequested)
					return;

				_inputHandler.Enable();

				await towerDisassembling;
				await obstacleDisappearing.ApplyAsync();
			}
		}
	}
}