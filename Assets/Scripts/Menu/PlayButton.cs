using System;
using GameStates.Base;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;
using UnityObject = UnityEngine.Object;

namespace Menu
{
	[RequireComponent(typeof(Button))]
	public class PlayButton : MonoBehaviour
	{
		[SerializeField] private GameStateMachineSo _stateMachine;
		
		private void Start()
		{	
			Button button = GetComponent<Button>();
			button.onClick.AddListener(_stateMachine.Enter<LevelEntryStateSo>);
		}


	}
}