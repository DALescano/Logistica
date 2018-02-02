using Med.Comun.Core;
namespace Logistica.Framework
{
    public static class StatusResponseManager
    {
        public static StatusResponse Warning(string message)
        {
            return new StatusResponse() { Message = message, Success = false };
        }
        public static StatusResponse Success()
        {
            return new StatusResponse() { Success = true };
        }
        public static StatusResponse Success(string message)
        {
            return new StatusResponse() { Message = message, Success = true };
        }
    }
}
