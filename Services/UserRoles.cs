namespace ITask7.Services;

public static class UserRoles
{
    public static readonly List<string> List = ["Admin", "Active", "Blocked"];
    public static string Admin => List[0];
    public static string Active => List[1];
    public static string Blocked => List[2];
}