namespace MyAPI_Entra21.Entity
{
    public class UserEntity
    {
        public int? Id { get; set; } // ? -> indica que PODE ser número
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}