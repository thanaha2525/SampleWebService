using Newtonsoft.Json;
using SampleWebService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Script.Serialization;
using System.Web.Services;
using static System.Net.WebRequestMethods;

namespace SampleWebService.Expressway
{
	/// <summary>
	/// Summary description for ExpresswayAccident
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class ExpresswayAccident : System.Web.Services.WebService
	{
		[WebMethod]
		public ExpresswayAccidentModel GetAccidentData()
		{
			var result = CallApi();
			return result;
		}


		private List<string> ExpresswayName(){
			return new List<string>{
				"ศรีรัช",
				"บูรพาวิถี",
				"เฉลิมมหานคร",
				"ทางหลวงพิเศษหมายเลข 37",
				"บางพลี-สุขสวัสดิ์",
				"ศรีรัช-วงแหวนรอบนอก",
				"ฉลองรัช"
			};
		}
		private ExpresswayAccidentModel CallApi(){
			try
			{
				string apiUrl = "https://exat-man.web.app/api/EXAT_Accident/2565/1";
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
				request.Method = "GET";
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				using (Stream stream = response.GetResponseStream())
				using (StreamReader reader = new StreamReader(stream))
				{
					string jsonResponse = reader.ReadToEnd();
					JavaScriptSerializer serializer = new JavaScriptSerializer();
					ExpresswayAccidentModel accidentModel = serializer.Deserialize<ExpresswayAccidentModel>(jsonResponse);
					return accidentModel;
				}
			}
			catch (Exception ex)
			{
				return new ExpresswayAccidentModel();
			}
		}
	}
}
