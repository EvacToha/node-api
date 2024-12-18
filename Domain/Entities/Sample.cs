using System.ComponentModel.DataAnnotations;
using System.Text.Json; 
using System.Text.Json.Serialization;

namespace NodeApl.API.Domain.Entities;

public class Sample
{
    [Key]
    public int Id { get; set; }
    [Required] [MaxLength(20)] 
    public string Name { get; set; } = "";
    [Required]
    [JsonConverter(typeof(CreateDateConverter))]
    public DateTime CreateDate { get; set; }
    [Required] [MaxLength(20)] 
    public string CreatedBy { get; set; } = "";
    [Required] 
    public int NodeId { get; set; }
    
    
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