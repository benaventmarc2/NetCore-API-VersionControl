using Api_VersionControl.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api_VersionControl.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/V{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersControllerV2 : ControllerBase
    {
        private const string ApiTestURL = "https://dummyapi.io/data/v1/user?limit=30";
        private const string AppID = "6457a9faac7a2938757c4796";
        private readonly HttpClient _httpClient;

        public UsersControllerV2(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> GetUsersDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("app-id", AppID);

            var response = await _httpClient.GetStreamAsync(ApiTestURL);
            var usersData = await JsonSerializer.DeserializeAsync<UsersResponseData>(response);

            var users = usersData?.data;

            return Ok(users);
        }
    }
}
