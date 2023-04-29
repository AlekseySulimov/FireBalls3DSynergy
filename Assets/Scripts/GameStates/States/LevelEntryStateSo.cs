using System;
using GameStates.Base;
using Ioc;
using Levels;
using Levels.Generation;
using Levels.Interfaces;
using SceneLoading;
using Tools;
using UnityEngine;
using UnityEngine.Serialization;
using UnityObject = UnityEngine.Object;
namespace GameStates.States
{
	[CreateAssetMenu(fileName = "LevelEntryState", menuName = "ScriptableObjects/Game/States/LevelEntryState")]
	public class LevelEntryStateSo : GameStateSo
	{
		[SerializeField] private Scene _playerGeneratedPathScene;
		[SerializeField] private UnityObject _levelProvider;
			

		private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();
		private ILevelProvider LevelProvider => (ILevelProvider)_levelProvider;
		private Level Level => LevelProvider.Current;
	
		private void OnValidate()
		{
			Inspector.ValidateOn<ILevelProvider>(ref _levelProvider);
		}

		public override async void Enter()
		{
			Container.Register(new PathStructureContainer
			{
				PathStructure = Level.PathStructure
			});
			

			await _sceneLoading.LoadAsync(CurrentLevel().LocationScene);
			await _sceneLoading.LoadAsync(_playerGeneratedPathScene);
		}

		private Level CurrentLevel()
		{
			return LevelProvider.Current;
		}

		public override void Exit() { }
	}
}