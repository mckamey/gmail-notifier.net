using System;

namespace Notifier.Providers
{
	public class Notification
	{
		#region Fields

		private string id = null;
		private int count = -1;
		private int index = -1;
		private string title = null;
		private string author = null;
		private string body = null;
		private DateTime? timeStamp = null;
		private Uri link = null;

		#endregion Fields

		#region Init

		/// <summary>
		/// Ctor.
		/// </summary>
		/// <param name="id"></param>
		public Notification(string id)
		{
			this.id = id;
		}

		#endregion Init

		#region Properties

		public string ID
		{
			get { return this.id; }
		}

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

		public DateTime? Date
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
