using System;
using SQLite.Net.Attributes;

namespace YenCash
{
    [Table("UsersInfo")]
    public class UsersInfo
    {
        [PrimaryKey]
        public string UserID
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }

        public string UserPhoneNumber
        {
            get;
            set;
        }

        public string UserProfilePic
        {
            get;
            set;
        }

        public string UserEmailId
        {
            get;
            set;
        }


        public string SecurityCode
        {
            get;
            set;
        }
        public string UserPassword
        {
            get;
            set;
        }

        public string UserOTP
        {
            get;
            set;
        }
    }
}
