namespace DropZone.Core.Models.User
{
    public class AuthModel
    {
        public long? UserId { get; set; }

        public string Token { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccess { get; set; }
    }
}
