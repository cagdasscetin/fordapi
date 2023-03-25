using FordApi.Data;
using FordApi.Dto;
using FordApi.Service.Base;

namespace FordApi.Service.Abstract;

public interface IPersonService : IBaseService<PersonDto,Person>
{

}
