using System;

namespace Notifier.Providers
{
	public class Notification
	{
		#region Fields

		private int count = 0;
		private int index = 0;
		private string title = null;
		private string author = null;
		private string body = null;
		private DateTime timeStamp = DateTime.MinValue;
		private Uri link = null;

		#endregion Fields

		#region Properties

		public int Count
		{
			get { return this.count; }
			set { this.count = value; }
		}

		public int Index
		{
			get { return this.index; }
			set { this.index = value; }
		}

		public string Title
		{
			get { return this.title; }
			set { this.title = value; }
		}

		public DateTime TimeStamp
		{
			get { return this.timeStamp; }
			set { this.timeStamp = value; }
		}

		public string Author
		{
			get { return this.author; }
			set { this.author = value; }
		}

		public string Body
		{
			get { return this.body; }
			set { this.body = value; }
		}

		public Uri Link
		{
			get { return this.link; }
			set { this.link = value; }
		}

		#endregion Properties
	}
}
