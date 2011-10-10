using System;
using SiqualRunner.Core.Entities;

namespace SiqualRunner.Core
{
	public delegate void FileRanEventHandler(object sender, FileRanEventHandlerArgs args);

	public class FileRanEventHandlerArgs : EventArgs
	{
		private readonly SiqualFile _file;

		public SiqualFile File
		{
			get { return _file; }
		}

		public FileRanEventHandlerArgs(SiqualFile file)
		{
			_file = file;
		}
	}
}