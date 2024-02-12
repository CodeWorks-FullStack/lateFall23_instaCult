
using System.Net.Http;

namespace instaCult.Controllers;


[ApiController]
[Route("api/cults")]
public class CultsController : ControllerBase
{
  private readonly Auth0Provider auth;
  private readonly CultsService cultsService;

    public CultsController(CultsService cultsService, Auth0Provider auth)
    {
        this.cultsService = cultsService;
        this.auth = auth;
    }

    [HttpGet]
    public ActionResult<List<Cult>> GetAllCults()
    {
      try
      {
        List<Cult> cults = cultsService.GetAllCults();
        return Ok(cults);
      }
      catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpGet("{cultId}")]
    public ActionResult<Cult> GetCultById(int cultId)
    {
      try
      {
        Cult cult = cultsService.GetCultById(cultId);
        return Ok(cult);
      }
 catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Cult>> CreateCult([FromBody] Cult cultData)
    {
      try
      {
        Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
        cultData.LeaderId = userInfo.Id;
        Cult cult = cultsService.CreateCult(cultData);
        return Ok(cult);
      }
 catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpDelete("{cultId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteCult(int cultId)
    {
      try
      {
        Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
        string message = cultsService.DeleteCult(cultId, userInfo.Id);
        return Ok(message);
      }
      // NOTE first catch will catch any specific errors you throw
        catch (HttpRequestException error)
      {
        return StatusCode((int)error.StatusCode, error.Message);
      }
      // NOTE second catch will catch all other general errors, not thrown by you
        catch (Exception error)
      {
        return BadRequest(error.Message);
      }
    }
}