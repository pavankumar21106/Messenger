namespace MessengerInfrastructure.Services
{
    public class UserTokenGenarator
    {
        private readonly TokenGenarator _tokenGenarator;
        public UserTokenGenarator(TokenGenarator tokenGenarator)
        {
            _tokenGenarator = tokenGenarator;
        }

        public string GetUserToken(int id)
        {
            var token = _tokenGenarator.GetTokenGenaratorInstance().Encode(id);
            return token;
        }
        public int GetUserId(string token)
        {
            _tokenGenarator.GetTokenGenaratorInstance().TryDecodeSingle(token,out int id);
            return id;
        }
    }
}