using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoom_Integration.Models.Entities
{
	public class Room
	{
		public string name { get; set; }
        public List<string> participants { get; set; }
	}
}