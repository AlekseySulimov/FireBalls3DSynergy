using Obstacles.Sequence;
using Towers.Generation;

namespace Paths.Builders
{
	[System.Serializable]
	public struct PathPlatformStructure
	{
		public TowerStructureSo TowerStructure;
		public Obstacle[] Obstacles;
	}
}