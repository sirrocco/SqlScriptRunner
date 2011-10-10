using System.Windows.Forms;

namespace SiqualRunner
{
	public class BaseForm : Form
	{
		public NHTransaction NHTransaction
		{
			get
			{
				return new NHTransaction();
			}
		}
	}
}