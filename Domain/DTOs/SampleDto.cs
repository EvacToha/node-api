using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Domain.DTOs;

public class SampleDto
{
    
    public string Name { get; set; } = "";
    
    [JsonConverter(typeof(CreateDateConverter))]
    public DateTime CreateDate { get; set; }
    
    public int NodeId { get; set; }

    [Required] public string CreatedBy { get; set; } = "";


}

public class CreateDateConverter : JsonConverter<DateTime>
{
    private const string Format = "yyyy-MM-dd";
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString()!, Format, null);
    }
}    
