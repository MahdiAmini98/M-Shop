using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Shop.Data;
using M_Shop.Data.Repository;
using M_Shop.Models.View_Models;
using Microsoft.AspNetCore.Mvc;

namespace M_Shop.Components
{
    public class ListGroupComponent:ViewComponent
    {
        private IGroupRepository _groupRepository;

        public ListGroupComponent(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

      public  async Task<IViewComponentResult> InvokeAsync()
      {

            return View("/Views/Components/ListGroupComponent.cshtml", _groupRepository.GetGroupForShow());
        }
    }
}
