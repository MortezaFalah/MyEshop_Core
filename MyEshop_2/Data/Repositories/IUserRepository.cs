using MyEshop_2.Models;

namespace MyEshop_2.Data.Repositories
{
    public interface IUserRepository
    {

       bool IsExistUserByEmail(string email);

        void AddUser(Users user);

        Users GetUserForLogin(string Email, string password);
    }


    public class UserRepository : IUserRepository
    {
        private MyEshopContext2 _Context;

        public UserRepository(MyEshopContext2 context)
        {
            _Context = context;
        }
    
        public void AddUser(Users user)
        {
           _Context.Users.Add(user);
            _Context.SaveChanges();
        }

        public Users GetUserForLogin(string Email, string password)
        {
            return _Context.Users.SingleOrDefault(r => r.Email == Email && r.Password == password);
        }

        public bool IsExistUserByEmail(string email)
        {
            return _Context.Users.Any(r => r.Email == email);
        }
    }
}
