using DataPersistence.Files;
using Ioc;
using Levels;
using UnityEngine;

namespace DataPersistence.Saves.Saves
{
	public class LevelSave : MonoBehaviour
	{
		[SerializeField] private FilePathSo _filePath;
	
		private readonly IAsyncFileService _fileService = new JsonNetFileService();

		private void OnApplicationQuit()
		{
			LevelNumber levelNumber = Container.InstanceOf<LevelNumber>();
			_fileService.SaveAsync(levelNumber, _filePath.Value);
		}
	}
}