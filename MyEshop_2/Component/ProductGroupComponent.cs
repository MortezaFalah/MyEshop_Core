using Microsoft.AspNetCore.Mvc;
using MyEshop_2.Data;
using MyEshop_2.Data.Repositories;
using MyEshop_2.Models;

namespace MyEshop_2.Component
{
    public class ProductGroupComponent:ViewComponent
    {
        private IGroupRepository _GroupRepository;

        public ProductGroupComponent(IGroupRepository groupRepository)
        {
            _GroupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cat = _GroupRepository.GetGroupForSow();
            return View("/Views/Component/ProductGroupComponent.cshtml",cat);
        }
    }
}
