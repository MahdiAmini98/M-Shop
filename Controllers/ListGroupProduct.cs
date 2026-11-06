using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Shop.Data;
using M_Shop.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace M_Shop.Controllers
{
    public class ListGroupProduct : Controller
    {
      
        private IGroupRepository _repository;

        public ListGroupProduct(IGroupRepository repository)
        {
            _repository = repository;
        }

        //نشان دادن محصولات در لیست گروه ها

        [Route("/Group/{id}/{name}")]
        public IActionResult ShowProductByListGroup(int id, string name)
        {

            ViewData["GroupName"] = name;
            return View(_repository.ShowProductByListGroup(id,name));
        }
    }
}
