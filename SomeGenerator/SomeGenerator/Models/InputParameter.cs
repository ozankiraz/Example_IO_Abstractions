using Newtonsoft.Json;

namespace SomeGenerator;

public class InputParameter
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }
}