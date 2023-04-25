using System.Collections.Generic;
using Towers.Generation.Disassembling;

namespace Towers
{
	public class Tower
	{
		private readonly Queue<TowerSegment> _segments;
		public Tower(IEnumerable<TowerSegment> segments) : this(new Queue<TowerSegment>(segments)) { }
		public Tower(Queue<TowerSegment> segments)
		{
			_segments = segments;
		}

		public TowerSegment RemoveBottom() => _segments.Dequeue();
	}
}