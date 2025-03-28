﻿using SWD392_AffiliLinker.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD392_AffiliLinker.Services.Interfaces
{
	public interface IJwtTokenService
	{
		Task<string> GenerateJwtToken(User user);
		Task<string> GenerateRefreshToken(User user);

    }
}
