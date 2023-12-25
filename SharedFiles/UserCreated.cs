namespace SharedFiles;

public interface UserCreated
{
    public Guid Id { get; set; }
    
    public string UserName { get; set; }
    
    public string Password { get; set; }
}