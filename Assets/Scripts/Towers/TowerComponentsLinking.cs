using System;
using System.Threading.Tasks;
using Shooting.Pool;
using Towers.Generation;
using Towers.Generation.Disassembling;
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
		
		private TowerDisassembling _disassembling;
		private Tower _tower;

		[ContextMenu(nameof(Prepare))]
		public async Task Prepare()
		{
			_tower = await _generator.Generate();
			_disassembling = new TowerDisassembling(_tower, _towerRoot);
			_projectileHitTrigger.ProjectileReturned += _disassembling.RemoveBottom;
		}

		private void OnDisable()
		{
			if (_disassembling != null)
			{
				_projectileHitTrigger.ProjectileReturned -= _disassembling.RemoveBottom;
			}
		}
	}
}