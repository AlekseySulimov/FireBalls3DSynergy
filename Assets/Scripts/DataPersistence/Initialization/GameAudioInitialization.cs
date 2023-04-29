using System.Collections.Generic;
using System.Threading.Tasks;
using Audio;
using DataPersistence.Files;
using System.Collections.Generic;
using System.Threading.Tasks;
using Audio;
using DataPersistence.Files;
using DataPersistence.Saves;
using Ioc;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;

namespace DataPersistence.Initialization
{
	public class GameAudioInitialization : AsyncInitialization
	{
		[SerializeField] private FilePathSo _filePath;

		private readonly IAsyncFileService _fileService = new JsonNetFileService();

		public override async Task InitializeAsync()
		{
			var preferences = await _fileService.LoadAsync<IEnumerable<AudioPreferences>>(_filePath.Value) ?? EnsureCreated();

			AudioMixer mixer = await Addressables.LoadAssetAsync<AudioMixer>("AudioMixer").Task;

			GameAudio gameAudio = new GameAudio(mixer, preferences);
			gameAudio.Initialize();
			
			Container.Register<IAudioOperations>(gameAudio);
			Container.Register<IAudioPreferencesProvider>(gameAudio);
			Container.Register<IAudioStatusProvider>(gameAudio);
		}

		private IEnumerable<AudioPreferences> EnsureCreated() => new[]
		{
			new AudioPreferences(AudioGroup.BackgroundMusic, 0.0f),
			new AudioPreferences(AudioGroup.Sfx, 0.0f)
		};
	}
}