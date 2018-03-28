using System;

using Xamarin.Forms;
using YenCash;
using SQLite.Net;

namespace YenCash
{
    public class DatabaseMethods : IDatabaseMethods
    {
        static SQLiteConnection sqliteconnection;
        public DatabaseMethods()
        {
            //try
            //{
            sqliteconnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteconnection.CreateTable<DeviceTokenInfo>();
            sqliteconnection.CreateTable<UsersInfo>();
            //}
            //catch (Exception ex)
            //{
            //  var msg = ex.Message;
            //}
        }

        public void SaveDeviceToken(string deviceToken, string deviceUDID)
        {
            try
            {
                sqliteconnection.Query<DeviceTokenInfo>("delete from DeviceTokenInfo");
                sqliteconnection.Insert(new DeviceTokenInfo
                {
                    DeviceToken = deviceToken,
                    DeviceUDID = deviceUDID
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DeviceTokenInfo GetDeviceToken()
        {
            return sqliteconnection.Table<DeviceTokenInfo>().FirstOrDefault();
        }


        /// <summary>
        /// Create User Info in local database
        /// </summary>
        /// 

        public void SaveUserInfo(userInfo objUserInfo)
        {
            try
            {
                //sqliteconnection.Query<UsersInfo> ("delete from UsersInfo");
                var UserInfo = sqliteconnection.Table<UsersInfo>().Where(x => x.UserID == (objUserInfo.UserId)).FirstOrDefault();

                if (UserInfo == null)
                {
                    sqliteconnection.Insert(new UsersInfo
                    {
                        UserID = objUserInfo.UserId,
                        UserName = objUserInfo.Name,
                        UserPhoneNumber = objUserInfo.MobileNumber,
                        SecurityCode = objUserInfo.SecurityCode,
                        UserEmailId = objUserInfo.EmailId,
                        UserProfilePic = objUserInfo.UserProfileImageUrl,
                        UserPassword = objUserInfo.OldPassword,
                        UserOTP = objUserInfo.OTP
                    });
                }
                else
                {
                    UserInfo.UserID = objUserInfo.UserId;
                    UserInfo.UserName = objUserInfo.Name;
                    UserInfo.UserPhoneNumber = objUserInfo.MobileNumber;
                    UserInfo.SecurityCode = objUserInfo.SecurityCode;
                    UserInfo.UserEmailId = objUserInfo.EmailId;
                    UserInfo.UserProfilePic = objUserInfo.UserProfileImageUrl;
                    UserInfo.UserPassword = objUserInfo.OldPassword;
                    UserInfo.UserOTP = objUserInfo.OTP;
                    sqliteconnection.Update(UserInfo);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public userInfo GetUserInfo()
        {
            try
            {

                var userInfo = sqliteconnection.Table<UsersInfo>().FirstOrDefault();
                if (userInfo != null)
                {

                    userInfo objUserInfo = new userInfo()
                    {
                        UserId = userInfo.UserID.ToString(),
                        Name = userInfo.UserName,
                        MobileNumber = userInfo.UserPhoneNumber,
                        SecurityCode = userInfo.SecurityCode,
                        EmailId = userInfo.UserEmailId,
                        UserProfileImageUrl = userInfo.UserProfilePic,
                        OldPassword = userInfo.UserPassword,
                        OTP = userInfo.UserOTP
                    };
                    return objUserInfo;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserInfo(userInfo objUserInfo)
        {
            var UserInfo = sqliteconnection.Table<UsersInfo>().FirstOrDefault();

            UserInfo.UserID = objUserInfo.UserId;
            UserInfo.UserName = objUserInfo.Name;
            UserInfo.UserPhoneNumber = objUserInfo.MobileNumber;
            UserInfo.SecurityCode = objUserInfo.SecurityCode;
            UserInfo.UserEmailId = objUserInfo.EmailId;
            UserInfo.UserPassword = objUserInfo.OldPassword;
            UserInfo.UserProfilePic = objUserInfo.UserProfileImageUrl;
            UserInfo.UserOTP = objUserInfo.OTP;
            sqliteconnection.Update(UserInfo);
        }

        public void DeleteUserInfo()
        {
            try
            {

                sqliteconnection.Query<userInfo>("delete from UsersInfo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DatabaseMethods() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}