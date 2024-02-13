



namespace instaCult.Services;

public class CultsService(CultsRepository repo)
{
    private readonly CultsRepository repo = repo;
    // NOTE a cult does not need a cultMember to exist, so lets keep all cultMember dependencies away from this service IF POSSIBLE


    internal Cult CreateCult(Cult cultData)
    {
        Cult cult = repo.CreateCult(cultData);
        return cult;
    }

    internal string DeleteCult(int cultId, string userId)
    {
        Cult cultToDelete = GetCultById(cultId);
        // NOTE how to write a more specific error for your code, specifying which response type you want
        if (cultToDelete.LeaderId != userId) throw new HttpRequestException("Not Authorized to edit", null, HttpStatusCode.Forbidden);
        // if(cultToDelete.LeaderId != userId) throw new Exception("Not yours!");

        repo.DeleteCult(cultId);
        return $"{cultToDelete.Name} was deleted";
    }

    internal List<Cult> GetAllCults()
    {
        List<Cult> cults = repo.GetAllCults();
        return cults;
    }

    internal Cult GetCultById(int cultId)
    {
        Cult cult = repo.GetCultById(cultId);
        if (cult == null) throw new Exception($"no cult at id: {cultId}");
        return cult;
    }
}