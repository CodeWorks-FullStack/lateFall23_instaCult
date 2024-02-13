namespace instaCult.Controllers;



[ApiController]
[Route("api/cultMembers")]
public class CultMembersController : ControllerBase
{
  private readonly CultMembersService cultMembersService;
  private readonly Auth0Provider auth;

  public CultMembersController(CultMembersService cultMembersService, Auth0Provider auth)
  {
      this.cultMembersService = cultMembersService;
      this.auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<CultMemberProfile>> CreateCultMember([FromBody] CultMember cultMemberData)
  {
    try
    {
      Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
      cultMemberData.AccountId = userInfo.Id;
      CultMemberProfile cultist = cultMembersService.CreateCultMember(cultMemberData);
      return Ok(cultist);

    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

}