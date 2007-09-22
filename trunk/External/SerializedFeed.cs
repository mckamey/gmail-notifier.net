using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Notifier.Feeds
{
	public abstract class SerializedFeed<T> : BaseFeed
	{
		#region BaseFeed Members

		protected override object ParseFeed(Stream stream)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			T feed = (T)serializer.Deserialize(stream);
			return feed;

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
