using System;
using GameStates.Base;
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
		[SerializeField] private PathStructureContainerSo _pathStructureContainer;
			

		private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();
		private ILevelProvider LevelProvider => (ILevelProvider)_levelProvider;
	
		private void OnValidate()
		{
			Inspector.ValidateOn<ILevelProvider>(ref _levelProvider);
		}

		public override async void Enter()
		{
			_pathStructureContainer.PathStructure = CurrentLevel().PathStructure;

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