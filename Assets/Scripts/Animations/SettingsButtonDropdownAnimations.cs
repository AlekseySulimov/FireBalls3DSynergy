using System;
using DG.Tweening;
using TweenStructures;
using UnityEngine;
using UnityEngine.Serialization;

namespace Animations
{
	public class SettingsButtonDropdownAnimations : MonoBehaviour
	{
		[SerializeField] private Vector2RangedTweenData _buttonsTweenData;
		[SerializeField] private GameObject _actionRoot;
		[SerializeField] private float _delayBetweenButtons;

		private RectTransform[] _buttonsTransforms;
		private bool _active;

		private void Start()
		{
			_buttonsTransforms = _actionRoot.GetComponentsInChildren<RectTransform>();
			TweenButtonSizes(_active, _buttonsTweenData);
		}

		public void OnButtonClicked()
		{
			_active = !_active;
			TweenButtonSizes(_active, _buttonsTweenData);
		}

		private void TweenButtonSizes(bool active, Vector2RangedTweenData tweenData)
		{
			float delay = 0.0f;
			foreach (RectTransform buttonTransform in _buttonsTransforms)
			{
				Vector2 sizeDelta = active ? tweenData.To : tweenData.From;
				buttonTransform
					.DOSizeDelta(sizeDelta, tweenData.Duration)
					.SetDelay(delay)
					.SetEase(tweenData.Ease);

				delay += _delayBetweenButtons;
			}
		}
	}
}