using DG.Tweening;
using UnityEngine;

namespace TweenStructures
{
	[System.Serializable]
	public class Vector3TweenData :TweenData<Vector3> { }
	
	public class TweenData<T>
	{
		public T EnaValue;
		public float Duration;
		public Ease Ease;
	}
}