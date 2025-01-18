using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Utils.Logging
{
	public interface ILog
	{
		void Trace(object value);
		void Trace(string msg, params object[] p);
		void Debug(object value);
		void Debug(string msg, params object[] p);
		void Info(object value);
		void Info(string msg, params object[] p);
		void Warn(object value);
		void Warn(string msg, params object[] p);
		void Error(object value);
		void Error(string msg, params object[] p);
		void Fatal(object value);
		void Fatal(string msg, params object[] p);
		void LogException(Exception e);
	}

	public class ConsoleLog : ILog
	{
		public void Debug(object value)
		{
			System.Diagnostics.Debug.WriteLine(value.ToString());
		}

		public void Debug(string msg, params object[] p)
		{
			System.Diagnostics.Debug.WriteLine(msg);
		}

		public void Error(object value)
		{
			System.Diagnostics.Debug.WriteLine(value.ToString());
		}

		public void Error(string msg, params object[] p)
		{
			System.Diagnostics.Debug.WriteLine(msg);
		}

		public void Fatal(object value)
		{
			System.Diagnostics.Debug.WriteLine(value.ToString());
		}

		public void Fatal(string msg, params object[] p)
		{
			System.Diagnostics.Debug.WriteLine(msg);
		}

		public void Info(object value)
		{
			System.Diagnostics.Debug.WriteLine(value.ToString());
		}

		public void Info(string msg, params object[] p)
		{
			System.Diagnostics.Debug.WriteLine(msg);
		}

		public void LogException(Exception e)
		{
			System.Diagnostics.Debug.WriteLine(e.Message);
		}

		public void Trace(object value)
		{
			System.Diagnostics.Debug.WriteLine(value.ToString());
		}

		public void Trace(string msg, params object[] p)
		{
			System.Diagnostics.Debug.WriteLine(msg);
		}

		public void Warn(object value)
		{
			System.Diagnostics.Debug.WriteLine(value.ToString());
		}

		public void Warn(string msg, params object[] p)
		{
			System.Diagnostics.Debug.WriteLine(msg);
		}
	}
}
