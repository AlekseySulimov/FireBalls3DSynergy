using System;
using System.Collections.Generic;
using Obstacles;
using Paths;
using Paths.Builders;
using UnityEngine;

namespace Levels.Generation
{
	[CreateAssetMenu(fileName = "LevelStructure", menuName = "ScriptableObject/Levels/LevelStructure", order = 0)]
	public class LevelStructureSo : ScriptableObject
	{
		[SerializeField] private Path _pathPrefab;
		[SerializeField] private List<PathPlatformStructure> _platforms = new List<PathPlatformStructure>();

		private void OnValidate()
		{
			if (_pathPrefab is null)
			{
				return;			
			}

			for (var i = 0; i < _pathPrefab.Segments.Count; i++)
			{
				_platforms.Add(default);
			}
		}

		public Path CreatePath(Transform pathRoot, ObstacleCollisionFeedback feedback)
		{
			Path path = Instantiate(_pathPrefab, pathRoot);
			path.Initialize(_platforms,feedback);
			return path;
		}
	}
}