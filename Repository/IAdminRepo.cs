namespace LoginAndRegistration.Repository
{
    public interface IAdminRepo<Admin>
    {

        public  List<Admin> GetAllAdmins();
        public List<Admin> SelectAdminBy_id(int Admin_id);
        public void insertAdmin(Admin A);

        public void updateadmin(Admin A,int Admin_id);

        public bool deleteadmin(int Admin_id);   

        
    }
}
