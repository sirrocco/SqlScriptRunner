using System.Collections.Generic;

namespace SiqualRunner.Infrastructure
{
	public static class IEnumerableExtensions
	{
		public static IEnumerable<OUTPUT> MapAllUsing<INPUT, OUTPUT>(this IEnumerable<INPUT> inputList, IMapper<INPUT, OUTPUT> mapper)
		{
			IList<OUTPUT> outputList = new List<OUTPUT>();

			foreach (INPUT item in inputList)
			{
				outputList.Add(mapper.Map(item));
			}

			return outputList;
		}
	}

	public interface IMapper<INPUT, OUTPUT>
	{
		OUTPUT Map(INPUT input);
	}
}