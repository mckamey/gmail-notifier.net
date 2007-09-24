using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace Notifier.Utils
{
	/// <summary>
	/// Helper class for launching a web browser
	/// </summary>
	public static class BrowserUtility
	{
		#region Methods

		public static void LaunchBrowser(Uri website)
		{
			if (website != null && website.IsAbsoluteUri)
			{
				BrowserUtility.LaunchBrowser(website.AbsoluteUri);
			}
		}

		public static void LaunchBrowser(string website)
		{
			if (!String.IsNullOrEmpty(website))
			{
				Process process = new Process();
				process.StartInfo.FileName = BrowserUtility.GetDefaultBrowser();
				process.StartInfo.Arguments = website;
				process.Start();
			}
		}

		#endregion Methods

		#region Private Methods

		private static string GetDefaultBrowser()
		{
			string browser = String.Empty;
			RegistryKey key = null;
			try
			{
				key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

				//trim off quotes
				browser = ((string)key.GetValue(null));
				if (browser == null)
				{
					return "iexplorer.exe";
				}
				browser = browser.Replace("\"", "");
				if (!browser.EndsWith("exe", StringComparison.OrdinalIgnoreCase))
				{
					//get rid of everything after the ".exe"
					browser = browser.Substring(0, browser.LastIndexOf(".exe", StringComparison.OrdinalIgnoreCase)+4);
				}
			}
			finally
			{
				if (key != null)
				{
					key.Close();
				}
			}
			return browser;
		}

		#endregion Private Methods
	}
}
