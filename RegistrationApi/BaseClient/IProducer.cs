using DomainLayer.Entities;

namespace RegistrationApi.BaseClient
{
    public interface IProducer
    {
        void ReadMessage(User user);
    }
}
