using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace YenCash
{
	[Table("DeviceTokenInfo")]
	public class DeviceTokenInfo
	{
		 public string DeviceToken {
			get;
			set;
		}
		public string DeviceUDID {
			get;
			set;
		}
	}
}

