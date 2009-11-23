using System.Reflection;

namespace CHSNS.NVelocityEngine {
	/// <summary>
	/// Provides a helper to access static operations on types to NVelocity.
	/// </summary>
	/// <typeparam name="T">the type to access</typeparam>
	public class StaticAccessorHelper<T> : global::NVelocity.IDuck {
		#region IDuck Members

		/// <summary>
		/// Invoke a get operation on the value type
		/// </summary>
		/// <param name="propName">the property or field to get</param>
		/// <returns>the value</returns>
		public object GetInvoke(string propName) {
			return
				typeof(T).InvokeMember(propName,
										BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField |
										BindingFlags.GetProperty,
										null, null, new object[] { });
		}
		/// <summary>
		/// Invoke a method on the value type
		/// </summary>
		/// <param name="method">the method name</param>
		/// <param name="args">the argumenents.</param>
		/// <returns>the result of the method invocation.</returns>
		public object Invoke(string method, params object[] args) {
			return
				typeof(T).InvokeMember(method, BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod,
										null, null, args);
		}
		/// <summary>
		/// Invoke a set operation on the value type
		/// </summary>
		/// <param name="propName">the property or field to set</param>
		/// <param name="value">the value to set the property or field to.</param>
		public void SetInvoke(string propName, object value) {
			typeof(T).InvokeMember(propName,
									BindingFlags.Public | BindingFlags.Static | BindingFlags.SetField |
									BindingFlags.SetProperty,
									null, null, new object[] { value });
		}
		#endregion
	}
}
