using GameStates.Base;
using SceneLoading;
using UnityEngine;

namespace GameStates.States
{
	[CreateAssetMenu(fileName = "MenuEntryState", menuName = "ScriptableObjects/Game/States/MenuEntryState")]
	public class MenuEntryStateSo : GameStateSo
	{
		[SerializeField] private Scene _locationScene;

		private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();
		public override void Enter()
		{
			_sceneLoading.LoadAsync(_locationScene);
		}

		public override void Exit() { }
	}
}