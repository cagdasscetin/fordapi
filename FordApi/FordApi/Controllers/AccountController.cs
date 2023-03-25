using FordApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FordApi.Web.Controllers;

[Route("ford/api/v1.0/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    private AppDbContext context;
    public AccountController(IUnitOfWork unitOfWork, AppDbContext context)
    {
        this.unitOfWork = unitOfWork;
        this.context = context;
    }


    [HttpGet]
    public List<Account> GetAll()
    {
        List<Account> accountList0 = context.Set<Account>().Where(x=> x.Email =="deny").AsNoTracking().Take(500).ToList();
        List<Account> accountList = unitOfWork.AccountRepository.GetAll();
        return accountList;
    }

    [HttpGet("{id}")]
    public Account GetById(int id)
    {
        Account account1 = context.Set<Account>().Find(id);
        Account account2 = context.Account.Find(id);
        Account account3 =  unitOfWork.AccountRepository.GetById(id);
        return account1;
    }



}
