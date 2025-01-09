using NodeApl.API.Domain.DTOs;

namespace NodeApl.API.Domain.Responses;

public class SampleAddResponse
{
    public SampleDto SampleDto { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}