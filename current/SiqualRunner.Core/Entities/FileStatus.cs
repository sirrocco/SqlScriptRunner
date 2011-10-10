using System;
using Undrtake.Infrastructure.Entity;

namespace SiqualRunner.Core.Entities
{
	public class FileStatus : EntityWithTypedId<int>
	{
		private string _errorMessage;

		public virtual DatabaseServer RanFor { get; set; }
		public virtual DateTime RanOn { get; set; }
		public virtual TimeSpan RunTime { get; set; }

		public virtual string ErrorMessage
		{
			get { return _errorMessage; }
			set
			{
				if (value == null) return;
				_errorMessage = value.Length > 1000 ? value.Substring(0, 999) : value;
			}
		}

		public virtual EnumRunStatus RunStatus
		{
			get;
			set;
		}
	}
}