using System;
using LoginAndRegistration.Models;
using LoginAndRegistration.Repository;

namespace LoginAndRegistration.Services
{
    public class AdminService
    {

        private readonly IAdminRepo<Admin> adminService = new AdminRepo();

        public AdminService()
        { }
        public AdminService(IAdminRepo<Admin> A)
        {
            adminService = A;
        }

        public List<Admin>GetAllAdmins()
        {
            return adminService.GetAllAdmins();
        }

        public void insertAdmin(Admin A)
        {
            adminService.insertAdmin(A);
        }

        public void UpdateAdmin(Admin A,int Admin_id)
        {
            adminService.updateadmin(A,Admin_id);
        }

        public bool DeleteAdmin(int Admin_id)
        {
            bool i=adminService.deleteadmin(Admin_id); 
            return i;   
        }

        public List<Admin> SelectAdminBy_id(int Admin_id)
        {
            return adminService.SelectAdminBy_id(Admin_id);

        }


    }
}
