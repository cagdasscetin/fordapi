using FordApi.Base;
using FordApi.Dto;
using FordApi.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FordApi.Web.Controllers;

[Route("ford/api/v1.0/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService service;
    public AccountController(IAccountService service)
    {
        this.service = service;
    }


    [HttpGet]
    public BaseResponse<List<AccountDto>> GetAll()
    {
        Log.Debug("AccountController.GetAll");
        var response = service.GetAll();
        return response;
    }

    [HttpGet("{username}")]
    public BaseResponse<AccountDto> GetByUsername([FromRoute] string username)
    {
        Log.Debug("AccountController.GetByUsername");
        var response = service.GetByUsername(username);
        return response;
    }


    [HttpGet("{id}")]
    public BaseResponse<AccountDto> GetById(int id)
    {
        Log.Debug("AccountController.GetById");
        var response = service.GetById(id);
        return response;
    }

    [HttpPost]
    public BaseResponse<bool> Post([FromBody] AccountDto request)
    {
        Log.Debug("AccountController.Post");
        var response = service.Insert(request);
        return response;
    }

    [HttpPut("{id}")]
    public BaseResponse<bool> Put(int id, [FromBody] AccountDto request)
    {
        Log.Debug("AccountController.Put");
        var response = service.Update(id, request);
        return response;
    }

    [HttpDelete("{id}")]
    public BaseResponse<bool> Delete(int id)
    {
        Log.Debug("AccountController.Delete");
        var response = service.Remove(id);
        return response;
    }

}
