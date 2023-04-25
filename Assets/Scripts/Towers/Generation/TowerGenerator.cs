using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using TweenStructures;
using UnityEngine;
using UnityEngine.Serialization;
using UnityObject = UnityEngine.Object;

namespace Towers.Generation
{
	public class TowerGenerator : MonoBehaviour
	{
		[SerializeField] private TowerFactorySo _towerFactory; 
		[SerializeField] private Transform _towerRoot;
		[SerializeField] private Vector3TweenData _rotationData;
		
		private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

		public ITowerSegmentCreationCallBack CreationCallback => _towerFactory;
		private void OnDisable()
		{
			_cancellationTokenSource.Cancel();
		}

		[ContextMenu(nameof(Generate))]
		public async Task<Tower> Generate()
		{
			ApplyRotation(_rotationData);
			return await _towerFactory.CreateAsync(_towerRoot, _cancellationTokenSource.Token);
		}

		private void ApplyRotation(Vector3TweenData rotationData)
		{
			_towerRoot
				.DORotate(rotationData.To, rotationData.Duration, RotateMode.FastBeyond360)
				.SetEase(rotationData.Ease);
		}
	}
}