using UnityEngine;

namespace Levels
{
	[CreateAssetMenu(menuName = "LevelNumber", fileName = "ScriptableObjects/Level/LevelNumber")]
	public class LevelNumberSo : ScriptableObject
	{
		public int Value;
	}
}