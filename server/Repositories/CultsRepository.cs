


using System.Runtime.InteropServices;

namespace instaCult.Repositories;

public class CultsRepository(IDbConnection db)
{
  private readonly IDbConnection db = db;

    internal Cult CreateCult(Cult cultData)
    {
      string sql = @"
      INSERT INTO cults
      (name, coverImg, leaderId, bio)
      VALUES
      (@name, @coverImg, @leaderId, @bio);

      SELECT
        cults.*,
        accounts.*
      FROM cults
      JOIN accounts ON cults.leaderId = accounts.id
      WHERE cults.id = LAST_INSERT_ID();
      ";
      Cult cult = db.Query<Cult, Profile, Cult>(sql, (cult, profile)=>{
        cult.Leader = profile;
        return cult;
      }, cultData).FirstOrDefault();
      return cult;
    }

    internal void DeleteCult(int cultId)
    {
      string sql = @"
      DELeTE FROM cults WHERE cults.id = @cultId;
      ";
      db.Execute(sql, new{cultId});
    }

    internal List<Cult> GetAllCults()
    {
      string sql = @"
      SELECT
        cults.*,
        accounts.*
      FROM cults
      JOIN accounts ON cults.leaderId = accounts.id;
      ";
      List<Cult> cults = db.Query<Cult, Profile, Cult>(sql, (cult, profile)=>{
        cult.Leader = profile;
        return cult;
      }).ToList();
      return cults;
    }

    internal Cult GetCultById(int cultId)
    {
      string sql = @"
      SELECT
        cults.*,
        accounts.*
      FROM cults
      JOIN accounts ON cults.leaderId = accounts.id
      WHERE cults.id = @cultId;
      ";
      Cult cult = db.Query<Cult, Profile, Cult>(sql, (cult, profile)=>{
        cult.Leader = profile;
        return cult;
      }, new{cultId}).FirstOrDefault();
      return cult;
    }
}