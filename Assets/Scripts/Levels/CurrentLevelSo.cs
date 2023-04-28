using System;
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
		[SerializeField] private LevelNumberSo _levelNumber;


		public int Value => _levelNumber.Value;
		public Level Current => _storage._levels[_levelNumber.Value - 1];

		public void StepToNextLevel()
		{
			_levelNumber.Value = Math.Clamp(_levelNumber.Value + 1, 1, _storage.Levels.Count);
		}
	}
}