using System;

namespace Jalomieli.Debug
{
	public class Assert
	{
		public static void NotNull(object obj, string readableName = "argument")
		{
			if (obj == null)
			{
				var message = string.Format("{0} cannot be null.", readableName);
				throw new Exception(message);
			}
		}
	}
}