using Newtonsoft.Json;

namespace SomeGenerator;

public class InputReader : IInputReader
{
    public IEnumerable<InputParameter> Read(string inputFile)
    {
        var inputParameters = JsonConvert.DeserializeObject<IEnumerable<InputParameter>>(File.ReadAllText(inputFile));

        return inputParameters;
    }
}

public interface IInputReader
{
    IEnumerable<InputParameter> Read(string inputFile);
}
