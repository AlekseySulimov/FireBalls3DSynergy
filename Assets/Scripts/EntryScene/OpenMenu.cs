using GameStates.Base;
using GameStates.States;
using UnityEngine;

namespace EntryScene
{
	public class OpenMenu : MonoBehaviour
	{
		
		[SerializeField] private GameStateMachineSo _stateMachine;
		
		private void Start()
		{	
			_stateMachine.Enter<MenuEntryStateSo>();
		}
	}
}