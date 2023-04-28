using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
	[CreateAssetMenu(fileName = "LevelLoseState", menuName = "ScriptableObjects/Game/States/LevelLoseState")]
	public class LevelLoseState : GameStateSo
	{
		[SerializeField] private Scene _menu;
		private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();
		
		public override void Enter()
		{
			_sceneLoading.LoadAsync(_menu);
		}

		public override void Exit()
		{
		}
	}
}