/*
 * Created by: efi efi.merdler@gmail.com
 * Created: Sunday, April 29, 2007
 */
using System;
using System.Collections.Generic;
using System.Xml;
using Zoombut.VisualSurveillanceLaboratory.OutputSystem;
using Zoombut.VisualSurveillanceSystem.Properties;

namespace Zoombut.VisualSurveillanceLaboratory
{
	public class OutputSystemFactory
	{
		/// <summary>
		/// Singleton instance.
		/// </summary>
		private static OutputSystemFactory instance = new OutputSystemFactory();

		/// <summary>
		/// Holds tracking systems that were found.
		/// </summary>
		private List<IOutputSystem> availableOutputSystems =
			new List<IOutputSystem>();

		/// <summary>
		/// Singleton constructor.
		/// </summary>
		private OutputSystemFactory()
		{
			// Load available tracking systems.
			XmlDocument document = new XmlDocument();
			document.Load(Settings.Default.ConfigFile);

			// Use xml path.
			XmlNodeList result = document.SelectNodes("/Configuration/OutputSystem");
			foreach (XmlNode node in result)
			{
				// Load values.
				String location = node.Attributes["location"].InnerText;
				String className = node.Attributes["class"].InnerText;

				// Create instance.
				IOutputSystem value;
				try
				{
					value =
						(IOutputSystem) Activator.CreateInstanceFrom(location, className).Unwrap();
					availableOutputSystems.Add(value);
				}catch(Exception)
				{
					// Ignore
					//TODO Notify the user.
				}
			}
		}

		/// <summary>
		/// Get singleton instance.
		/// </summary>
		public static OutputSystemFactory GetInstance()
		{
			return instance;
		}

		/// <summary>
		/// Gets the available tracking systems.
		/// </summary>
		/// <value>The available tracking systems.</value>
		public IList<IOutputSystem> AvailableOutputSystems
		{
			get { return availableOutputSystems.AsReadOnly(); }
		}
	}
}