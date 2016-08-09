using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoistFm.Enum
{
	public enum Error
	{
		InvalidService = 2,
		InvalidMethod = 3,
		AuthenticationFailed = 4,
		InvalidFormat = 5,
		InvalidParameters = 6,
		InvalidResourceSpecified = 7,
		OperationFailed = 8,
		InvalidSessionKey = 9,
		InvalidApiKey = 10,
		ServiceOffline = 11,
		InvalidMethodSignatureSupplied = 13,
		TemporaryError = 16,
		SuspendedApiKey = 26,
		RateLimitExceeded = 29
	}
}
