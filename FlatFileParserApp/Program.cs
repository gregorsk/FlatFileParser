// See https://aka.ms/new-console-template for more information
using FlatFileParser;

Console.WriteLine("Hello, World!");

    var parser = new FlatFileParser<Class1>();
parser.Configure((config) => {
    config
    .AddColumn("Id", 5, (s, record) => record.Id = int.Parse(s.Trim()))
    .AddColumn("Name", 10, (s, record) => record.Name = s.Trim())
    .Skip(5)
    .AddColumn("Description", 15, (s, record) => record.Description = s.Trim());
});

var input = File.OpenRead("test.txt");
var results = await parser.ParseAsync(input);
foreach (var result in results) {
    Console.WriteLine(result);
}

public class Class1
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public override string ToString()
    {
        return $"Object of type: {typeof(Class1)}. Values:\nId: {Id}, Name: {Name}, Description: {Description}.";
    }
}