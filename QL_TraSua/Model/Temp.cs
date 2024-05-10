namespace ShopSimple.Model
{
    public class Temp
    {
        private static string _user;
        private static bool _isAdmin;
        public static string User { get => _user; set => _user = value; }
        public static bool IsAdmin { get => _isAdmin; set => _isAdmin = value; }
    }
}