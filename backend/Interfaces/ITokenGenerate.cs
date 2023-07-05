using AngularBigbang.Models.DTO;

namespace AngularBigbang.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);

    }
}
