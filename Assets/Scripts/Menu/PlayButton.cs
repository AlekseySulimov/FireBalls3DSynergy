using System;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
	[RequireComponent(typeof(Button))]
	public class PlayButton : MonoBehaviour
	{
		private void Start()
		{	
			Button button = GetComponent<Button>();
			button.onClick.AddListener(LoadLevel);
		}

		private void LoadLevel()
		{
			
		}
	}
}