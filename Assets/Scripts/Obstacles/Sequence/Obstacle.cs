using UnityEngine;

namespace Obstacles.Sequence
{
	public class Obstacle : MonoBehaviour
	{
		[SerializeField] private ObstacleCollision _collision;

		public void Initialize(ObstacleCollisionFeedback feedback)
		{
			_collision.Initialize(feedback);
		}
	}
}