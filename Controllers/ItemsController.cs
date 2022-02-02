using System.Collections.Generic;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Catalog.Models ;
using System;
using System.Linq;
using Catalog.Dtos;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("(items)")]
    public class ItemsController : ControllerBase
    {
       private readonly IItemRepository repository ;

       public ItemsController(IItemRepository repository){
           this.repository =  repository ;
       }
      
      // GET /items
      [HttpGet]
       public IEnumerable<ItemDto> GetItems()
       {
           var items = repository.GetItems().Select(item => item.AsDto());
           return items ;
       }
       
       //GET /Items/{id}
       [HttpGet("{id}")]
       public ActionResult<ItemDto> GetItem(Guid id){
           var item = repository.GetItem(id) ;
           if(item is null)
           return NotFound() ;
           return item.AsDto() ;
       }
    }
}