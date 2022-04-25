using Microsoft.AspNetCore.Http;
using LoginAndRegistration.Models;
using LoginAndRegistration.Services;
using System.Linq;
using System.Collections.Generic;
using LoginAndRegistration.Repository;
using LoginAndRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginAndRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminService = new AdminService();
        

       

        [HttpGet]

        public ActionResult<List<Admin>> GetAllAdmin()
        {
            return Ok(adminService.GetAllAdmins());
        }
        [HttpGet]
        [Route("Get Admin by Id/{Admin_id}")]

        public ActionResult<List<Admin>> Get_AdminById(int Admin_id)
        {
            return Ok(adminService.SelectAdminBy_id(Admin_id)); 
           

        }


        [HttpPost]
        public ActionResult insertAdmin(Admin A)
        {
            adminService.insertAdmin(A);
            return Ok();
        }


        [HttpPut]
        [Route("update Admin/{Admin_id}")]
        public IActionResult UpdateAdmin(Admin A, int Admin_id)
        {
            adminService.UpdateAdmin(A, Admin_id);
            return Ok();

        }
        [HttpDelete]
        public IActionResult DeleteAdmin(int Admin_id)
        {
            bool b = adminService.DeleteAdmin(Admin_id);    
            if (b)
                return Ok();
            else
                return NotFound();
        }

    }
}
