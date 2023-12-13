using Dapper;
using MyAPI_Entra21.Contracts.Repository; //.Repo adicionado
using MyAPI_Entra21.DTO;
using MyAPI_Entra21.Entity;
using MyAPI_Entra21.Infraestructure;

namespace MyAPI_Entra21.Repository
{
    public class UserRepository : Connection, IUserRepository //Implementação da classe, com a interface
    {
        public async Task Add(UserDTO user) // @""Permite quebra de linha, para organização
        {
            string sql = @"
                INSERT INTO USER (Name, Email, Password)
                            VALUE (@Name, @Email, @Password)
            ";
            await Execute(sql, user); //é assíncrono, coloca await para executá-lo. Necessário uso de "async"

        }

        public async Task Delete(int id)
        {
            string sql = "DELETE FROM USER WHERE Id = @id";
            await Execute(sql, new { id });
        }

        public async Task<IEnumerable<UserEntity>> Get()
        {
            string sql = "SELECT * FROM USER";
            return await GetConnection().QueryAsync<UserEntity>(sql);

        }


        public async Task<UserEntity> GetById(int id)
        {
            string sql = "SELECT * FROM USER WHERE Id = @id";
            return await GetConnection().QueryFirstAsync<UserEntity>(sql, new { id });
        }


        public async Task Update(UserEntity user)
        {
            string sql = @"
                UPDATE USER 
                   SET Name = @Name, 
                       Email = @Email, 
                       Password = @Password
                 WHERE Id = @Id
            ";
            await Execute(sql, user);
        }
    }
}
