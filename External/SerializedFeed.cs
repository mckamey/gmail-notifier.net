using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Notifier.Providers
{
	public abstract class XmlNotifierProvider<T> : NotifierProvider where T : class
	{
		#region BaseFeed Members

		protected abstract List<Notification> ParseFeed(T feed);

		protected override List<Notification> ParseFeed(Stream stream)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			T feed = (T)serializer.Deserialize(stream);
			return this.ParseFeed(feed);

			//XPathDocument xDoc = new XPathDocument(stream);
			//XPathNavigator xNav = xDoc.CreateNavigator();
			////XmlNamespaceManager nsMgr = new XmlNamespaceManager(xNav.NameTable);
			////nsMgr.AddNamespace("atom", BaseAtomFeed.AtomNamespace);

			//XPathNodeIterator entries = xNav.SelectDescendants("entry", AtomFeed.AtomNamespace, true);
			//foreach (XPathNavigator entry in entries)
			//{
			//}

			//return entries.Count;
		}

		#endregion BaseFeed Members
	}
}
