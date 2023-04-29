using System;
using System.Threading;
using Ioc;
using Obstacles;
using Paths;
using Players;
using UnityEngine;

namespace Levels.Generation
{
	// without DI we need to set dependencies by linking component through all level down
	// Level builder it is start to that. It composition root
	public class LevelBuilder : MonoBehaviour
	{
		[Header("Path")]
		[SerializeField] private Transform _pathRoot;
		[SerializeField] private PathStructureContainer _pathStructureContainer;
		
		[Header("Player")] 
		[SerializeField] private PlayerMovement _playerMovement;
		[SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;
		
		private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
		private PathStructureSo PathStructure => _pathStructureContainer.PathStructure;

		private void Start()
		{
			Build();
		}

		private void OnDisable()
		{
			_cancellationTokenSource.Cancel();
		}

		private void Build()
		{
			Path path = Container
				.InstanceOf<PathStructureContainer>()
				.PathStructure.
				CreatePath(_pathRoot, _obstacleCollisionFeedback, _cancellationTokenSource);
			
			Vector3 initialPosition = path.Segments[0].Waypoints[0].position;
			
			_playerMovement.StartMovingOn(path, initialPosition, _cancellationTokenSource);
		}

	}
}