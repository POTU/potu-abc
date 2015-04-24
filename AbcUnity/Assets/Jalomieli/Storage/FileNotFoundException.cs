using System;

namespace Jalomieli.Storage
{
	public class FileNotFoundException : Exception
	{
		public FileNotFoundException(string message) : base(message)
		{
		}
	}
}