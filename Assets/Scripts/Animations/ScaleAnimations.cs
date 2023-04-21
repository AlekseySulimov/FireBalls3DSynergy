using DG.Tweening;
using TweenStructures;
using UnityEngine;

namespace Animations
{
	public class ScaleAnimations : MonoBehaviour
	{
		[SerializeField] private Vector3TweenData _tweenData;

		private void Start() => ApplyAnimation(_tweenData);

		private void ApplyAnimation(Vector3TweenData tweenData) =>
			transform
				.DOScale(tweenData.To, tweenData.Duration)
				.SetEase(tweenData.Ease)
				.SetLoops(-1, LoopType.Yoyo);
	}
}
