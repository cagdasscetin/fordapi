using FordApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace FordApi.Web.Controllers;

[Route("ford/api/v1.0/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    public PersonController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }


    [HttpGet]
    public List<Person> GetAll()
    {
        List<Person> list = unitOfWork.PersonRepository.GetAll();
        return list;
    }

    [HttpGet("{id}")]
    public Person GetById(int id)
    {
        Person person = unitOfWork.PersonRepository.GetById(id);
        return person;
    }

    [HttpPost]
    public void Post([FromBody] Person request)
    {
        unitOfWork.PersonRepository.Insert(request);
        unitOfWork.Complete();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Person request)
    {
        request.Id = id;
        unitOfWork.PersonRepository.Update(request);
        unitOfWork.Complete();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        unitOfWork.PersonRepository.Remove(id);
        unitOfWork.Complete();
    }
}
