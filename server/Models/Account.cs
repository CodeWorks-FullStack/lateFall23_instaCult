namespace instaCult.Models;


public class Profile : RepoItem<string>
{
  public string Name { get; set; }
  public string Picture { get; set; }
}

public class Account : Profile
{
  public string Email { get; set; }
  public string PhoneNumber { get; set; } 
  public string  CreditCardNumber { get; set; }
}

public class CultMemberProfile : Profile
{
  public int CultMemberId { get; set; }
}