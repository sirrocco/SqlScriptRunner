using System.Collections.Generic;
using System.Drawing;
using SiqualRunner.Core.Entities;

namespace SiqualRunner
{

	class ImageFactory
	{
		private static readonly string Directory = (System.IO.Directory.GetCurrentDirectory ( ) + @"\images\");

		private static readonly IDictionary<EnumRunStatus, Image> FileStatusImage = new Dictionary<EnumRunStatus, Image>
		                                                                         	{
		                                                                         		{
		                                                                         			EnumRunStatus.NotRan,
		                                                                         			Image.FromFile ( Directory+"delete.png" ) 
		                                                                         			},
		                                                                         		{
		                                                                         			EnumRunStatus.Fail,
		                                                                         			Image.FromFile ( Directory+"flag_red.png" ) 
		                                                                         			},
		                                                                         		{
		                                                                         			EnumRunStatus.Success,
		                                                                         			Image.FromFile ( Directory+"accept.png" ) 
		                                                                         			}	
		                                                                     		
		                                                                         	};

		public static Image GetStatusImg(EnumRunStatus status)
		{
			return FileStatusImage[status];
		}
	}
}