using System;

namespace Jalomieli.Storage
{
	public class InvalidDataException : Exception
	{
		public InvalidDataException(string message) : base(message)
		{
		}
	}
}