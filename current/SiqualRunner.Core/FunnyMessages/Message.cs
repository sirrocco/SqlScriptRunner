using System;
using System.Collections.Generic;
using System.Linq;

namespace SiqualRunner.Core.FunnyMessages
{
	public class Message
	{
		public string Text { get; set; }
		public int Type { get; set; }
	}

	public class MessageManager
	{
		private static readonly IList<Message> Messages = new List<Message>
		                                  	{
																				 new Message {Text="recalibrating", Type=0},
																				 new Message{Text="excavating", Type=0},
																				 new Message{Text="finalizing",Type= 0},
																				 new Message{Text="acquiring",Type= 0},
																				 new Message{Text="locking", Type=0},
																				 new Message{Text="fueling", Type=0},
																				 new Message{Text="extracting",Type= 0},
																				 new Message{Text="binding", Type=0},

																				 new Message {Text="flux", Type=1},
																				 new Message{Text="data",Type= 1},
																				 new Message{Text="spline", Type=1},
																				 new Message{Text="storage",Type= 1},
																				 new Message{Text="plasma",Type= 1},
																				 new Message{Text="cache",Type= 1},
																				 new Message{Text="laser",Type= 1},

																				 new Message {Text="capacitor",Type= 2},
																				 new Message{Text="conductor",Type= 2},
																				 new Message{Text="assembler",Type= 2},
																				 new Message{Text="disk",Type= 2},
																				 new Message{Text="detector",Type= 2},
																				 new Message{Text="post-processor",Type= 2},
																				 new Message{Text="integrator", Type=2}};

		public static string GetFunnyMessage()
		{
			return (from m in Messages
							from m1 in Messages
							from m2 in Messages
							where m.Type == 0 && m1.Type == 1 && m2.Type == 2
							orderby Guid.NewGuid()
							select m.Text + " " + m1.Text + " " + m2.Text).First();
		}
	}
}