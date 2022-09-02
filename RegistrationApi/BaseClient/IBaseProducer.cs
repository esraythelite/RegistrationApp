using DomainLayer.Entities;

namespace RegistrationApi.BaseClient
{
    public interface IBaseProducer
    {
        void ReadMessage(User user);
    }
}
