using UnityEngine;

namespace Characters
{
	[CreateAssetMenu(fileName = "CharacterContainer", menuName = "ScriptableObjects/Character/CharacterContainer")]
	public class CharacterContainerSo : ScriptableObject
	{
		public Character CharacterPrefab;

		public Character Create(Transform parent)
		{
			return Instantiate(CharacterPrefab, parent);
		}
	}
}