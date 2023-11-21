using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebService.Model
{
	public class ExpresswayAccidentDohModel
	{
		public string Date { get; set; }
		public string Time { get; set; }
		public string ExpresswayName { get; set; }
		public string Weather { get; set; }
		public string Cause { get; set; }
	}
}