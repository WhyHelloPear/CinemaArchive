using Core.Application.DTOs;

namespace Core.Application.Services
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetPeople();
    }
}
