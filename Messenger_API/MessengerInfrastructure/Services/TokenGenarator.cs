using HashidsNet;

namespace MessengerInfrastructure.Services
{
    public class TokenGenarator
    {
        private readonly Hashids _hashids;
        public TokenGenarator()
        {
            _hashids = new Hashids("litiIahqWFMhGQesNUbo", 32);
        }

        public Hashids GetTokenGenaratorInstance()
        {
            return _hashids;
        }
    }
}