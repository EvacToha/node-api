namespace NodeApl.API.Domain.Responses;

public class SampleDeleteResponse
{
    public List<int> DeletedIds { get; set; }
    public List<int> FailedIds { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}