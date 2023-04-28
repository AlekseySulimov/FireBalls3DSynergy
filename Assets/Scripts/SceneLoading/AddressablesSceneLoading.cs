using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace SceneLoading
{
	public class AddressablesSceneLoading : IAsyncSceneLoading
	{
		private readonly Dictionary<string, SceneInstance> _loadedScenes = new Dictionary<string, SceneInstance>();
		public async Task LoadAsync(Scene scene)
		{
			if (scene.LoadMode == LoadSceneMode.Single)
			{
				_loadedScenes.Clear();
			}
			SceneInstance sceneInstance = await Addressables.LoadSceneAsync(scene.Name, scene.LoadMode).Task;
			_loadedScenes.Add(scene.Name, sceneInstance);
		}

		public Task UnloadAsync(Scene scene)
		{
			SceneInstance sceneInstance = _loadedScenes[scene.Name];
			return Addressables.UnloadSceneAsync(sceneInstance).Task;
		}
	}
}