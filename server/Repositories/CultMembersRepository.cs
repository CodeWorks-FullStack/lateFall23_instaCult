


namespace instaCult.Repositories;


public class CultMembersRepository(IDbConnection db)
{
  private readonly IDbConnection db = db;

    internal CultMemberProfile CreateCultMember(CultMember cultMemberData)
    {
      string sql = @"
      INSERT INTO cultMembers
      (accountId, cultId)
      VALUES
      (@accountId, @cultId);

      SELECT
        cultMembers.*,
        accounts.*
      FROM cultMembers
      JOIN accounts ON cultMembers.accountId = accounts.id
      WHERE cultMembers.id = LAST_INSERT_ID();
      ";

      CultMemberProfile cultist = db.Query<CultMember, CultMemberProfile, CultMemberProfile>(sql, (cultMember, cultMemberProfile)=>{
        // NOTE the map is to always give our return type, the data it doesn't store in it's table
        cultMemberProfile.CultMemberId = cultMember.Id;
        return cultMemberProfile;
      }, cultMemberData).FirstOrDefault();
      return cultist;
    }

    internal List<CultMemberProfile> GetCultMembersByCultId(int cultId)
    {
      string sql = @"
      SELECT
        cultMembers.*,
        accounts.*
      FROM cultMembers
      JOIN accounts ON cultMembers.accountId = accounts.id
      WHERE cultMembers.cultId = @cultId;
      ";

      List<CultMemberProfile> cultists = db.Query<CultMember, CultMemberProfile, CultMemberProfile>(sql, (cultMember, cultMemberProfile)=>{
        cultMemberProfile.CultMemberId = cultMember.Id;
        return cultMemberProfile;
      }, new{cultId}).ToList();
      return cultists;
    }

    internal List<CultViewModel> GetMyCults(string userId)
    {
      string sql = @"
      SELECT
        cults.*,
        cultMembers.*,
        accounts.*
      FROM cultMembers
      JOIN cults ON cultMembers.cultId = cults.id
      JOIN accounts ON cults.leaderId = accounts.id
      WHERE cultMembers.accountId = @userId;
      ";
      List<CultViewModel> myCults = db.Query<CultViewModel, CultMember, Profile, CultViewModel>(sql, (cultViewModel, cultMember, profile)=>{
        // NOTE the map is to always give our return type, the data it doesn't store in it's table
        cultViewModel.CultMemberId = cultMember.Id;
        cultViewModel.Leader = profile;
        return cultViewModel;
      }, new{userId}).ToList();
      return myCults;
    }
}