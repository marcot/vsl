/*
 * Created by: efi merdlee@kdictionaries.com
 * Created: Saturday, April 28, 2007
 */
using System;
using System.Collections.Generic;
using System.Xml;
using Zoombut.VisualSurveillanceLaboratory.SurveillanceSystem;
using Zoombut.VisualSurveillanceSystem.Properties;

namespace Zoombut.VisualSurveillanceLaboratory
{
	/// <summary>
	/// Enumarates available trackign systems.
	/// </summary>
	public class TrackingSystemsFactory
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static TrackingSystemsFactory instance = new TrackingSystemsFactory();

		/// <summary>
		/// Holds tracking systems that were found.
		/// </summary>
		private List<ISurveillanceSystem> availableTrackingSystems =
			new List<ISurveillanceSystem>();

		/// <summary>
		/// Singleton constructor.
		/// </summary>
		private TrackingSystemsFactory()
		{
			// Load available tracking systems.
			XmlDocument document = new XmlDocument(); 
			document.Load(Settings.Default.ConfigFile);
			
			// Use xml path.
			XmlNodeList result = document.SelectNodes("/Configuration/TrackingSystem");
			foreach (XmlNode node in result)
			{
				// Load values.
				String location = node.Attributes["location"].InnerText;
				String className = node.Attributes["class"].InnerText;

				// Create instance.
				try
				{
					ISurveillanceSystem value =
						(ISurveillanceSystem)
						Activator.CreateInstanceFrom(location, className).Unwrap();
					availableTrackingSystems.Add(value);
				}catch (Exception)
				{
					// Ignore
					//TODO Notify the user.
				}
			}
		}

		/// <summary>
		/// Get singleton instance.
		/// </summary>
		public static TrackingSystemsFactory GetInstance()
		{
			return instance;
		}

		/// <summary>
		/// Gets the available tracking systems.
		/// </summary>
		/// <value>The available tracking systems.</value>
		public IList<ISurveillanceSystem> AvailableTrackingSystems
		{
			get { return availableTrackingSystems.AsReadOnly(); }
		}
	}
}