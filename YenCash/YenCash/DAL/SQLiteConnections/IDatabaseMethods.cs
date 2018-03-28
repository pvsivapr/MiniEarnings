using System;
namespace YenCash
{
    public interface IDatabaseMethods// : IDisposable
    {
        void SaveDeviceToken(string deviceToken, string deviceUDID);
        DeviceTokenInfo GetDeviceToken();

        void SaveUserInfo(userInfo objUserInfo);
        userInfo GetUserInfo();

        void UpdateUserInfo(userInfo objUserInfo);
        void DeleteUserInfo();
    }
}
