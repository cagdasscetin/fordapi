using FordApi.Base;
using FordApi.Data;
using FordApi.Dto;
using FordApi.Service.Base;

namespace FordApi.Service.Abstract;

public interface IAccountService : IBaseService<AccountDto,Account>
{
    BaseResponse<AccountDto> GetByUsername(string username);
}
