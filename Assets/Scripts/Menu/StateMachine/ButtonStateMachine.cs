using System;
using StateMachine;
using UnityEngine;

namespace Menu.StateMachine
{
	public class ButtonStateMachine : MonoBehaviour
	{
		[SerializeField] private MonoState[] _states = Array.Empty<MonoState>();
		private int _currentStateIndex;

		private void Start() => 
			Initialize();

		public void ChangeOnNextState()
		{
			_currentStateIndex = GetNextNextStateIndex(_currentStateIndex);
			_states[_currentStateIndex].Enter();
		}

		private void Initialize()
		{
			if (_states.Length == 0)
			{
				throw new InvalidOperationException("States should be initialized");
			}
			_currentStateIndex = 0;
			_states[_currentStateIndex].Enter();
		}

		private int GetNextNextStateIndex(int currentIndex) => 
			(currentIndex + 1) % _states.Length;
	}
}