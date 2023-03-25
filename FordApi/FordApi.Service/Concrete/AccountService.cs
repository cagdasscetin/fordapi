﻿using AutoMapper;
using FordApi.Base;
using FordApi.Data;
using FordApi.Dto;
using FordApi.Service.Abstract;
using FordApi.Service.Base;

namespace FordApi.Service.Concrete;

public class AccountService : BaseService<AccountDto, Account>, IAccountService
{
    private readonly IGenericRepository<Account> genericRepository;
    private readonly IMapper mapper;
    public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<Account> genericRepository) : base(unitOfWork, mapper, genericRepository)
    {
        this.genericRepository = genericRepository;
        this.mapper = mapper;
    }

    public BaseResponse<AccountDto> GetByUsername(string username)
    {
        var account = genericRepository.Where(x=> x.UserName == username).FirstOrDefault(); 
        var mapped = mapper.Map<Account,AccountDto>(account);
        return new BaseResponse<AccountDto>(mapped);
    }
}
