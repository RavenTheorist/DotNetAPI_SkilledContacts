using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.UI.Application.DTOs
{
	public class SkillResumeDTO
	{
		#region Properties
		public int NbSkillsFromThisContact { get; set; }
		public string SkillName { get; set; }
		public int SkillLevel { get; set; }
		public string ContactEmail { get; set; }
		#endregion//Properties
	}
}
