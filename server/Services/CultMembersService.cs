


namespace instaCult.Services;


public class CultMembersService(CultMembersRepository repo, CultsService cultsService)
{
    private readonly CultMembersRepository repo = repo;
    private readonly CultsService cultsService = cultsService;
    // NOTE a cultMember DOES depend on cults existing, so we can inject CULT type dependencies here

    internal CultMemberProfile CreateCultMember(CultMember cultMemberData)
    {
        Cult cult = cultsService.GetCultById(cultMemberData.CultId);
        // REVIEW idk is there any other rules we want to implement here? maybe i have to be the owner or something?
        CultMemberProfile cultist = repo.CreateCultMember(cultMemberData);
        return cultist;
    }

    internal List<CultMemberProfile> GetCultMembersByCultId(int cultId)
    {
      Cult cult = cultsService.GetCultById(cultId);
      // REVIEW idk is there any other rules we want to implement here? maybe i have to be the owner or something?
      List<CultMemberProfile> cultists = repo.GetCultMembersByCultId(cultId);
      return cultists;
      
    }

    internal List<CultViewModel> GetMyCults(string userId)
    {
      List<CultViewModel> myCults = repo.GetMyCults(userId);
      return myCults;
    }
}