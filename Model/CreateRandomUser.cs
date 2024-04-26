namespace PlayWrightCSharp.Model;

public class CreateRandomUser
{
    public string? username { get; set; }
    public string? password {  get; set; }
    public string? first_name{ get; set;}
    public string? last_name { get; set; }

}

public enum CreateRandomUserType
{
    USERNAME,
    PASSWORD,
    FIRSTNAME,
    LASTNAME
}
