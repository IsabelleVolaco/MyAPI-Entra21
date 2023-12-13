using Microsoft.AspNetCore.Mvc;
using MyAPI_Entra21.Contracts.Repository; //.Repo adicionado
using MyAPI_Entra21.DTO;
using MyAPI_Entra21.Entity;

namespace MinhaApiBonita.Controllers
{
    [ApiController]
    [Route("user")] // endereço da rota. Pode ter nomes diferentes, este foi um exemplo
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository; //não dropa a não ser na injeção de dependência

        public UserController(IUserRepository userRepository) //Construtor que faz o new UserRepository e coloca na variável, ele está injetando uma dependência
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userRepository.Get()); //await pede para esperar para executar, então faz funcionar [na videoaula a diferença de GET e ADD são explciadas]
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userRepository.GetById(id)); //retorna antes de "_UserRepository.Add(user);" ser executado, então mais uma vez é necessário await
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDTO user)
        {
            await _userRepository.Add(user);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserEntity user)
        {
            await _userRepository.Update(user);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepository.Delete(id);
            return Ok();
        }
    }
}