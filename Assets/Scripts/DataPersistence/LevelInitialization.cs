using System;
using Ioc;
using Levels;
using UnityEngine;

namespace DataPersistence
{
	public class LevelInitialization :MonoBehaviour
	{
		private void OnEnable()
		{
			Container.Register(new LevelNumber() { Value = 1});
		}
	}
}