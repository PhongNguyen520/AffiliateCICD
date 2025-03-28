using SWD392_AffiliLinker.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SWD392_AffiliLinker.Repositories.Entities
{
	public class Report : BaseEntity
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public string Status { get; set; }
		public string? RelyForReportId { get; set; }
		public string CampaignId { get; set; }
		public virtual Campaign Campaign { get; set; }
		public Guid UserId { get; set; }
		public virtual User User { get; set; }
	}
}
