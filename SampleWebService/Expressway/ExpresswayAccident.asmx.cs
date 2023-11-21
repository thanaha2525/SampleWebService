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

		[WebMethod]
		public List<result> GetAccidentDataResult(){
			var query = CallApi();
			var result = query.result;
			return result;
		}

		[WebMethod]
		public List<result> GetAccidntDataByExpressway(string expressway)
		{
			var query = CallApi();
			var result = query.result.Where(x => x.expw_step == expressway).ToList();
			return result;
		}

		[WebMethod]
		public result GetAccidentById(int id){
			var query = CallApi();
			var result = query.result.FirstOrDefault(x => x._id == id);
			return result;
		}

		[WebMethod]
		public List<string> GetNameExpressway(){
			return ExpresswayName();
		}
		
		[WebMethod]
		public List<ExpresswayAccidentDohModel> GetExpresswayAccidentDoh(){
			var query = CallApi();
			var result = query.result.Select(x => new ExpresswayAccidentDohModel{
				Date = x.accident_date,
				Time = x.accident_time,
				ExpresswayName = x.expw_step,
				Weather = x.weather_state,
				Cause = x.cause
			}).ToList();
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
