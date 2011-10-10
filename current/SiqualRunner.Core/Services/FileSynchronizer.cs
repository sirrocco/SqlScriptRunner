using System.Collections.Generic;
using System.IO;
using System.Linq;
using SiqualRunner.Core.Entities;

namespace SiqualRunner.Core.Services
{
	public interface IFileSynchronizer
	{
    bool SyncFileCollectionFromPath ( ICollection<SiqualFile> files, DatabaseServer server,
		                                Project project);
	}

	public class FileSynchronizer : IFileSynchronizer
	{
	  private bool _filesChanged;

	  public bool SyncFileCollectionFromPath(ICollection<SiqualFile> files, DatabaseServer server, Project project)
		{
			string folderPath = project.FolderPath;
      if (!Directory.Exists(folderPath))
        return false;

			string[] filePaths = Directory.GetFiles(folderPath, "*.sql", SearchOption.AllDirectories);

			IList<SiqualFile> filesRemovedFromPath = new List<SiqualFile>();

			foreach (SiqualFile file in files)
			{
			  if (filePaths.FirstOrDefault(x => x == file.FullFilePath) != null) continue;
			  
        filesRemovedFromPath.Add(file);
			  _filesChanged = true;
			}

			foreach (string filePath in filePaths)
			{
			  if (files.FirstOrDefault(x => x.FullFilePath == filePath) != null) continue;
			  
        files.Add(new SiqualFile(filePath, server, project));
			  _filesChanged = true;
			}

			foreach (SiqualFile fileToRemove in filesRemovedFromPath)
			{
				files.Remove(fileToRemove);
			}

		  return _filesChanged;
		}
	}
}