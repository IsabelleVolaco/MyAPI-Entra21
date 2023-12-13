using MyAPI_Entra21.DTO;
using MyAPI_Entra21.Entity;

namespace MyAPI_Entra21.Contracts.Repository
{
    public interface IUserRepository
    {
        Task Add(UserDTO user);
        Task Update(UserEntity user);
        Task Delete(int id);
        Task<UserEntity> GetById(int id);
        Task<IEnumerable<UserEntity>> Get();
    }
}
