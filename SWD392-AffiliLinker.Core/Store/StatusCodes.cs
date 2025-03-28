﻿using SWD392_AffiliLinker.Core.Utils;

namespace SWD392_AffiliLinker.Core.Store
{
	public enum StatusCodes
	{
		[CustomName("Success")]
		OK = 200,

		[CustomName("Bad Request")]
		BadRequest = 400,

		[CustomName("Unauthorized")]
		Unauthorized = 401,

		[CustomName("Internal Server Error")]
		ServerError = 500,

		[CustomName("Not Found")]
		NotFound = 404
	}
}
