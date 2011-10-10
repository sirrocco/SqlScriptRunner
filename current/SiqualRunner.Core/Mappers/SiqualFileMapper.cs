using System;
using System.Linq;
using SiqualRunner.Core.Entities;
using SiqualRunner.Infrastructure;

namespace SiqualRunner.Core.Mappers
{
	public class SiqualFileMapper : IMapper<SiqualFile, SiqualFileDisplay>
	{
		private readonly DatabaseServer _databaseServer;

		public SiqualFileMapper(DatabaseServer databaseServer)
		{
			_databaseServer = databaseServer;
		}

		public SiqualFileDisplay Map(SiqualFile input)
		{
			SiqualFileDisplay fileDisplay = new SiqualFileDisplay
																		{
																			FileName = input.FileName,
																			FilePath = input.FullFilePath,
																			Id = input.Id
																		};

			FileStatus status = input.FileStatuses.FirstOrDefault(x => x.RanFor != null && x.RanFor.Id == _databaseServer.Id);
			if (status == null)
				return fileDisplay;

			fileDisplay.RanOn = status.RanOn;
			fileDisplay.RanTime = status.RunTime;
			fileDisplay.RunStatus = status.RunStatus;
			fileDisplay.ErrorMessage = status.ErrorMessage;


			return fileDisplay;
		}
	}

	public class SiqualFileDisplay
	{
		public int Id;
		public string FilePath { get; set; }

		public string FileName { get; set; }

		public DateTime RanOn { get; set; }

		public TimeSpan RanTime { get; set; }

		public string RanTimeFormatted
		{
			get
			{
				return string.Format("{0:0000}", RanTime.Milliseconds);
			}
		}

		public EnumRunStatus RunStatus { get; set; }

		public string ErrorMessage { get; set; }
	}
}