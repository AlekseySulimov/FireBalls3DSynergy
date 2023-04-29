using System.IO;
using UnityEngine;

namespace DataPersistence
{
	[CreateAssetMenu(fileName = "FilePath", menuName = "ScriptableObject/Data/FilePath")]
	public class FilePathSo : ScriptableObject
	{
		[SerializeField] private string _fileName;
		
		public string Value => Path.Combine(DirectoryPath, _fileName);

		private string DirectoryPath =>
			Application.isEditor
				? Application.streamingAssetsPath
				: Application.persistentDataPath;

	}
}