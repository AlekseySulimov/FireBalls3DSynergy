using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
	[CreateAssetMenu(fileName = "GameAudio", menuName = "ScriptableObjects/Audio/GameAudio")]
	public class GameAudioSo : ScriptableObject, IAudioOperations, IAudioPreferencesProvider, IAudioStatusProvider
	{
		[SerializeField] private AudioMixer _audioMixer;

		private GameAudio _audio;

		public void Initialize(IEnumerable<AudioPreferences> audioPreferences)
		{
			_audio = new GameAudio(_audioMixer, audioPreferences);
			_audio.Initialize();
		}
		
		public void Enable(AudioGroup audioGroup) => 
			_audio.Enable(audioGroup);

		public void Disable(AudioGroup audioGroup) => 
			_audio.Disable(audioGroup);

		public IEnumerable<AudioPreferences> Preferences => _audio.Preferences;
		
		public AudioStatus StatusOf(AudioGroup group) => 
			_audio.StatusOf(group);
	}
}