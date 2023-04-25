using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Towers.Generation
{
	public interface IAsyncTowerFactory
	{
		Task<Tower> CreateAsync(Transform tower, CancellationToken cancellationToken);
	}
}