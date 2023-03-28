namespace ProjectECommerce_Api.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }


        public User(int id, string name, string email, Gender gender)
        {
            UserId = id;
            UserName = name;
            Email = email;
            Gender= gender;
        }
        public User() { }
    }
}
