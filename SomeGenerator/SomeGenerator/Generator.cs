namespace SomeGenerator
{
    public class Generator : IGenerator
    {
        private readonly IInputReader _inputReader;

        public Generator(IInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        public void Generate(string inputFile, string templateFile)
        {
            var inputParameters = _inputReader.Read(inputFile);

            var template = File.ReadAllText(templateFile);

            var templateParameters = inputParameters.Select(s => 
            new TemplateParameter 
            { 
                Name = s.Name, 
                Location = s.Location, 
                Description = "Lorem Ipsum Dolor Sit Amet" }
            ).ToList();

            templateParameters.ForEach(templateParameter =>
            {
                var content = template.FormatWithDictionary(
                    new Dictionary<string, string>() 
                    {
                        { "name", templateParameter.Name },
                        { "location", templateParameter.Location },
                        { "description", templateParameter.Description}
                    });

                File.WriteAllText($"{templateParameter.Name}_{templateParameter.Location}.out", content);
            });
        }
    }

    public interface IGenerator
    {
        void Generate(string inputFile, string templateFile);
    }
}
