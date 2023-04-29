using System;
using System.Collections.Generic;
using System.Linq;
using Audio;
using Extensions;
using Ioc;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Audio
{
	[RequireComponent(typeof(Image))]
	public class ToggleAudioButton : MonoBehaviour
	{
		[Serializable]
		private struct AudioStatusIcon
		{
			public AudioStatus Status;
			public Sprite Icon;
		}
		
		[SerializeField] private AudioGroup _group;
		[SerializeField] private AudioStatusIcon[] _icons;

		private Dictionary<AudioStatus, Sprite> _statuses;
		private Dictionary<AudioStatus, Action> _operations;
		
		private Image _image;

		private IAudioOperations _audioOperations;
		private IAudioStatusProvider _statusProvider;

		private void Awake()
		{
			_image = GetComponent<Image>();

			_audioOperations = Container.InstanceOf<IAudioOperations>();
			_statusProvider = Container.InstanceOf<IAudioStatusProvider>();
		}

		private void Start()
		{
			_statuses = _icons.ToDictionary(x => x.Status, x => x.Icon);
			_image.sprite = _statuses[_statusProvider.StatusOf(_group)];

			_operations = new Dictionary<AudioStatus, Action>
			{
				{AudioStatus.Enabled, () => _audioOperations.Enable(_group)},
				{AudioStatus.Disabled, () => _audioOperations.Disable(_group)}
			};
		}

		public void OnButtonClicked()
		{
			AudioStatus audioStatus = _statusProvider.StatusOf(_group).Next();
			_image.sprite = _statuses[audioStatus];
			_operations[audioStatus].Invoke();
		}
	}
}