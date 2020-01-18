using System;

namespace NaughtyAttributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class RequiredAttribute : ValidatorAttribute
	{
		public string Message { get; private set; }
        public bool LogToConsole { get; private set; }

		public RequiredAttribute(bool logToConsole = false, string message = null)
		{
            LogToConsole = logToConsole;
			Message = message;
		}
	}
}
