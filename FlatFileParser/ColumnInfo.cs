namespace FlatFileParser;

public class ColumnInfo<TRecord>
{
    public string Name { get; init; } = null!;
    public int Start { get; init; }
    public int Length { get; init; }
    public Type DataType { get { return typeof(TRecord); } }
    public Action<string, TRecord> AssignFunc { get; init; } = null!;
}
