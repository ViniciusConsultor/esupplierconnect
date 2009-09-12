using System;
using System.Xml;
using System.IO;
using System.Data;

namespace SAPInterface
{
	/// <summary>
	/// ----------------------------------------------------------------------------------
	/// Summary description for SAPLogin.
	/// This class provides methods to get the connection string for connecting to SAP
	/// System : eProcurement System
	/// Module : eProcurement and SAP Interface 
	/// Author : Chetan Potnis
	/// Dated  : 05/08/2009
	/// Class  : RetrieveContract
	/// ----------------------------------------------------------------------------------
	/// </summary>
	public class SAPLogin
	{
		private string aErrStr = "";
		private const string configFile = "C:\\eProcurement\\SAPConfig.xml";

		private string aSAPHostName, aSAPSystem, aSAPClient, aSAPUser,aSAPPswd, aConnStr;

		public SAPLogin()
		{
			this.GetConfiguration();
		}

		private void GetConfiguration()
		{
			FileInfo file;

			try
			{
				DataSet ConfigDataSet = new DataSet();
				file = new FileInfo(Environment.CurrentDirectory + "\\SAPConfig.xml");
				if (!file.Exists)
				{
					file = new FileInfo(configFile);
				}
				FileStream fsReadXml     = new FileStream(file.FullName, System.IO.FileMode.Open);
				XmlTextReader cXmlReader = new XmlTextReader(fsReadXml);
				ConfigDataSet.ReadXml(cXmlReader);
				cXmlReader.Close();
				fsReadXml.Close();

				aSAPHostName = ConfigDataSet.Tables[0].Rows[0].ItemArray[0].ToString(); 
				aSAPSystem   = ConfigDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
				aSAPClient   = ConfigDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
				aSAPUser     = ConfigDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
				aSAPPswd     = ConfigDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
			}
			catch(Exception ex)
			{	
				aErrStr = ex.Message;
			}
		}

		public string GetSAPConnection ()
		{
			aConnStr = "ASHOST=" + aSAPHostName + " SYSNR=" + aSAPSystem + " CLIENT=" +
				aSAPClient + " USER=" + aSAPUser + " PASSWD=" + aSAPPswd;

			return aConnStr;
		}

		public string getMessage ()
		{
			return aErrStr;
		}

	}
}
