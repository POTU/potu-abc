namespace Jalomieli.Debug
{
	public class Log
	{
		public static void Info(object message)
		{
			UnityEngine.Debug.Log(message);
		}

		public static void Info(object message, UnityEngine.Object source)
		{
			UnityEngine.Debug.Log(string.Format("{0}: {1}", source, message), source);
		}

		public static void Warning(object message)
		{
			UnityEngine.Debug.LogWarning(message);
		}

		public static void Warning(object message, UnityEngine.Object source)
		{
			UnityEngine.Debug.LogWarning(string.Format("{0}: {1}", source, message), source);
		}

		public static void Error(object message)
		{
			UnityEngine.Debug.LogError(message);
		}

		public static void Error(object message, UnityEngine.Object source)
		{
			UnityEngine.Debug.LogError(string.Format("{0}: {1}", source, message), source);
		}

		public static void Exception(System.Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}
}