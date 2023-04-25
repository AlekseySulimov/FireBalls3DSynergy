using TMPro;
using UnityEngine;

namespace UI.TowerSegmentsLeftText
{
	public class TowerSegmentsLeftText : MonoBehaviour
	{
		[SerializeField] private TextMeshPro _text;

		public void UpdateTextValue(int segmentCount)
		{
			_text.text = $"{segmentCount}";
		}

	}
}