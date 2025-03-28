using SWD392_AffiliLinker.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392_AffiliLinker.Repositories.Entities
{
	public class CampaignMember
	{
		public string Status { get; set; } = string.Empty;

		public string CampaignId { get; set; }
		public virtual Campaign Campaign { get; set; } = null!;

		public Guid UserId { get; set; }
		public virtual User User { get; set; } = null!;

		public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset LastUpdatedTime { get; set; } = DateTimeOffset.UtcNow;
		public DateTimeOffset? DeletedTime { get; set; }
	}
}
