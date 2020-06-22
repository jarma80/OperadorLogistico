using DataAccess;

namespace Domain
{
    public class UserModel
    {
        UserDAO userDAO = new UserDAO();
        public bool userLogin(string user, string pass, int rol) 
        {
            return userDAO.login(user, pass, rol);
        }
    }
}
