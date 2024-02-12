

public class Cult : RepoItem<int>{
  public string Name  { get; set; }
  public string CoverImg { get; set; }
  public string Bio { get; set; }
  public string LeaderId { get; set; }
  public Profile Leader { get; set; }
}