using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebService.Model
{
	public class ExpresswayAccidentModel
	{
		public int resultCode { get; set; }
		public List<result> result { get; set; } = new List<result>();
	}

	public class result
	{
		public int _id { get; set; }
		public string accident_date { get; set; }
		public string accident_time { get; set; }
		public string expw_step { get; set; }
		public string weather_state { get; set; }
		public int injur_man { get; set; }
		public int injur_femel { get; set; }
		public int dead_man { get; set; }
		public int dead_femel { get; set; }
		public string cause { get; set; }
	}
}