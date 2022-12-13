namespace FlatFileParser;

public class Configurator<TRecord>
{
    private int _currentPosition;

    public List<ColumnInfo<TRecord>> Columns { get; private set; } = new();

    public Configurator<TRecord> AddColumn(string name, int length, Action<string, TRecord> assignFunc)
    {
        var ci = new ColumnInfo<TRecord> {
            Name = name,
            Length = length,
            Start = _currentPosition,
            AssignFunc = assignFunc
        };

        Columns.Add(ci);
        _currentPosition += length;
        return this;
    }

    public Configurator<TRecord> Skip(int length)
    {
        _currentPosition += length;
        return this;
    }
}

