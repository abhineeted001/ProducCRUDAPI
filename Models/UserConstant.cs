namespace ProductCRUDAPI.Models
{
    public class UserConstant
    {
        public static List<UserModel> Users = new()
            {
                    new UserModel(){ Username="Advanced",Password="acs_admin",Role="Admin"}
            };
    }
}
