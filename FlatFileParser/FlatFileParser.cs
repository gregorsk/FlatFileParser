namespace FlatFileParser
{
    public partial class FlatFileParser<TRecord> where TRecord: new()
    {
        private Configurator<TRecord> _configurator = new();

        public async Task<IEnumerable<TRecord>> ParseAsync(Stream input)
        {
            var results = new List<TRecord>();

            var reader = new StreamReader(input);
            do
            {
                var line = await reader.ReadLineAsync();
                if (line == null){
                    break;
                }
                var result = ParseLine(line);
                if (result == null) {
                    break;
                }
                results.Add(result);
            } while (true);

            return results;
        }

        public void Configure(Action<Configurator<TRecord>> value)
        {
            value(_configurator);
        }

        private TRecord ParseLine(string line)
        {
            var record = new TRecord();
            
            foreach (var ci in _configurator.Columns)
            {
                var strValue = line.Substring(ci.Start, ci.Length);

                ci.AssignFunc(strValue, record);
            }

            return record;
        }
    }
}
