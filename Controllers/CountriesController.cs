using Microsoft.AspNetCore.Mvc;

namespace GeoLens.Api.Controllers;

[ApiController]
[Route("api/countries")]
public class CountriesController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public CountriesController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET: api/countries - For main list
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var url = "https://restcountries.com/v3.1/all?fields=name,cca3,capital,region,subregion,population,area,flags,currencies,languages";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to fetch countries from API");
            }

            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // GET: api/countries/{code} - For detail page
    [HttpGet("{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
        try
        {
            var url = $"https://restcountries.com/v3.1/alpha/{code}?fields=name,cca3,capital,region,subregion,population,area,flags,currencies,languages,latlng";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound($"Country with code '{code}' not found.");
            }

            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}