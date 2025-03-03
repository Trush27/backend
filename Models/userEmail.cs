namespace backend.Models;

public class userEmail
{
    public string Email { get; set; } = String.Empty;

    public userEmail()
    {
    }
    public userEmail(string Email)
    {
        this.Email = Email;
    }
}

