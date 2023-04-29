using System;
using Ioc;
using Levels.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Levels
{
	[CreateAssetMenu(fileName = "CurrentLevel", menuName = "ScriptableObjects/Levels/CurrentLevel" )]
	public class CurrentLevelSo : ScriptableObject,ILevelNumberProvider, ILevelProvider,ILevelChanging
	{
		[SerializeField] private LevelStorageSo _storage;
		 private LevelNumber LevelNumber => Container.InstanceOf<LevelNumber>();


		public int Value => LevelNumber.Value;
		public Level Current => _storage._levels[LevelNumber.Value - 1];

		public void StepToNextLevel()
		{
			LevelNumber.Value = Math.Clamp(LevelNumber.Value + 1, 1, _storage.Levels.Count);
		}
	}
}