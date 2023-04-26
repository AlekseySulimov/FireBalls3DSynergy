using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Towers.Generation
{
	[CreateAssetMenu(fileName = "TowerStructure", menuName = "ScriptableObjects/Tower/Structure", order = 0)]
	public class TowerStructureSo : ScriptableObject
	{
		[SerializeField] private TowerSegment _segmentsPrefab;
		
		[Space]
		[SerializeField] [Min(0)] private int  _segmentCount;
		[SerializeField] private float  _spawnTimePerSegment;

		[Space] 
		[SerializeField] private Material[] _materials = Array.Empty<Material>();
		public int SpawnTimePerSegmentsMillisecond => (int)(_spawnTimePerSegment * 1000);

		public TowerSegment SegmentsPrefab => _segmentsPrefab;

		public int SegmentCount => _segmentCount;
		private Material GetSegmentMaterialBy(int numberOfInstance)
		{
			int index = numberOfInstance % _materials.Length;
			return _materials[index];
		}

		
		public TowerSegment CreateSegment(Transform tower, Vector3 position, int numberOfInstance)
		{
			TowerSegment segment = Instantiate(_segmentsPrefab, position, tower.rotation, tower);
			
			Material material = GetSegmentMaterialBy(numberOfInstance);
			segment.SetMaterial(material);
			
			return segment;
		}


	}
}