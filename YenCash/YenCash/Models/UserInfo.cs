using System;

namespace YenCash
{
	public class User
	{
		public int StatusCode { get; set; }
		public int Status { get; set; }
		public string Message { get; set; }
		public userInfo ResponseInfo { get; set; }
	}

	public class userInfo
	{
		public string UserId { get; set; }
		public string Name { get; set; }
		public string EmailId { get; set; }
		public string MobileNumber { get; set; }
		public string SecurityCode { get; set; }
		public string UserProfileImageUrl { get; set; }
		public string OldPassword { get; set; }
        public string OTP { get; set; }
	}
}
