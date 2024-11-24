using System;

namespace BankAccountManagementSystem.Exceptions
{
	[Serializable]
	public class BankAccountManagementSystemException : Exception
	{
		public BankAccountManagementSystemException() { }
		public BankAccountManagementSystemException(string message) : base(message) { }
		public BankAccountManagementSystemException(string message, Exception inner) : base(message, inner) { }
		protected BankAccountManagementSystemException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}