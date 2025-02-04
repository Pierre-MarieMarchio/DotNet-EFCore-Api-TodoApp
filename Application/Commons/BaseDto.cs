using System;
using System.Text.Json.Serialization;

namespace TodoApi.Application.Commons;

public abstract class BaseDto
{
    public Guid Id { get; set; }
    
    [JsonIgnore]
    public bool ShouldValidateId { get; set; } = true;
}
