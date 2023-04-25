using System;
using System.Threading.Tasks;
using Shooting.Pool;
using Structures.ReactiveProperties;
using Towers.Generation;
using Towers.Generation.Disassembling;
using UI.TowerSegmentsLeftText;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Towers
{
	public class TowerComponentsLinking : MonoBehaviour
	{
		[SerializeField] private TowerGenerator _generator;
		[SerializeField] private Transform _towerRoot;
		[SerializeField] private RestoreProjectilePoolTrigger _projectileHitTrigger;
		[SerializeField] private TowerSegmentsLeftText _segmentsLeftText;
		
		private TowerDisassembling _disassembling;
		private Tower _tower;
		private IReadOnlyReactiveProperty<int> _towerSegmentCount = new FakeReactiveClass<int>();

		[ContextMenu(nameof(Prepare))]
		public async Task Prepare()
		{
			_generator.CreationCallback.SegmentCreated += _segmentsLeftText.UpdateTextValue;
			_tower = await _generator.Generate();
			
			_disassembling = new TowerDisassembling(_tower, _towerRoot);
			_projectileHitTrigger.ProjectileReturned += _disassembling.TryRemoveBottom;

			_towerSegmentCount = _tower.SegmentCount;
			_towerSegmentCount.Subscribe(_segmentsLeftText.UpdateTextValue);
		}

		private void OnDisable()
		{
			if (_disassembling != null)
			{
				_projectileHitTrigger.ProjectileReturned -= _disassembling.TryRemoveBottom;
			}
			
			_towerSegmentCount.Unsubscribe(_segmentsLeftText.UpdateTextValue);
			_generator.CreationCallback.SegmentCreated -= _segmentsLeftText.UpdateTextValue;
		}
	}
}