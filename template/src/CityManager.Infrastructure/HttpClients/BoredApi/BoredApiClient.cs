using System.Net;
using System.Text.Json;
using AutoMapper;
using CityManager.Application.Common.Dto;
using CityManager.Application.Common.Interfaces.Infrastructure.HttpClients.BoredApi;
using CityManager.Application.Common.Options;
using CityManager.Application.Exceptions;
using CityManager.Infrastructure.HttpClients.BoredApi.Models;
using Microsoft.Extensions.Options;

namespace CityManager.Infrastructure.HttpClients.BoredApi;

public class BoredApiClient : IBoredApiClient
{
    private readonly IOptions<ActivityOptions> _activityOptions;
    private readonly IMapper _mapper;

    public BoredApiClient(IOptions<ActivityOptions> activityOptions, IMapper mapper)
    {
        _activityOptions = activityOptions;
        _mapper = mapper;
    }
    
    public async Task<ActivityDto> GetRandomActivityAsync()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"{_activityOptions.Value.BoredApiRoot}/{_activityOptions.Value.ActivityEndpoint}");

        var response = await client.SendAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new NotFoundException();
        }
        
        string responseString = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        GetActivityResponse? parsedResponse = JsonSerializer.Deserialize<GetActivityResponse>(responseString, options);

        return parsedResponse != null
            ? _mapper.Map<ActivityDto>(parsedResponse)
            : throw new NotFoundException();
    }
}