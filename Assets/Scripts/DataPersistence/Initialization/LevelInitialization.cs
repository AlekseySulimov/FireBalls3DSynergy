using System.Threading.Tasks;
using DataPersistence.Files;
using Ioc;
using Levels;
using UnityEngine;

namespace DataPersistence.Initialization
{
	public class LevelInitialization : AsyncInitialization
	{
		[SerializeField] private FilePathSo _filePath;
		private readonly IAsyncFileService _fileService = new JsonNetFileService();
		public override async Task InitializeAsync()
		{
			LevelNumber levelNumber = await _fileService.LoadAsync<LevelNumber>(_filePath.Value);
			Container.Register(levelNumber);
		}
	}
}