using UnityEngine;

namespace GameStates.Base
{
	[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObjects/Game/States", order = 0)]
	public abstract class GameStateSo : ScriptableObject, IGameState
	{
		public abstract void Enter();
		public abstract void Exit();
	}
}