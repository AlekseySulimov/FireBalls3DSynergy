using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Towers.Generation.Disassembling
{
	public class TowerDisassembling
	{
		private readonly Tower _tower;
		private readonly Transform _towerRoot;
		public event Action Disassembled;
		public TowerDisassembling(Tower tower, Transform towerRoot)
		{
			_tower = tower;
			_towerRoot = towerRoot;
		}

		public void TryRemoveBottom()
		{
			if (_tower.SegmentCount.Value == 0 )
			{
				Disassembled?.Invoke();
				return;
			}
			TowerSegment segment = _tower.RemoveBottom();
			Vector3 segmentScale = segment.transform.localScale;

			_towerRoot.position -= Vector3.up * segmentScale.y;
			
			UnityObject.Destroy(segment.gameObject);
		}
	}
}