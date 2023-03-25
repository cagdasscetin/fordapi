using FordApi.Base;
using FordApi.Dto;

namespace FordApi.Service.Abstract;

public interface ITokenManagementService
{
    BaseResponse<TokenResponse> GenerateToken(TokenRequest request);
}
