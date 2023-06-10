using System.Collections.Frozen;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;

namespace DictionaryBenchmarks;

[MemoryDiagnoser(true)]
[DryJob]
public class Benchmarks
{
    private static IReadOnlyList<Int32> data;
    private static IReadOnlyList<Int32> shuffled_data;
    private FrozenDictionary<int, int> frozen_dictionary;
    private Dictionary<int, int> dictionary;
    private ImmutableDictionary<int, int> immutableDictionary;

    [Params(10_000_000)] public int N;

    [GlobalSetup]
    public void Setup()
    {
        data = Enumerable.Range(0, N).ToList().AsReadOnly();
        shuffled_data = data.OrderBy(x => $"alksjdljk{x}".GetHashCode()).ToList();
        frozen_dictionary = data.ToFrozenDictionary(x => x, x => x);
        dictionary = data.ToDictionary(x => x, x => x);
        immutableDictionary = data.ToImmutableDictionary(x => x, x => x);
    }

    [Benchmark]
    public void Initialization_Dictionary()
    {
        _ = data.ToDictionary(x => x, x => x);
    }

    [Benchmark]
    public void Initialization_ImmutableDictionary_CreateRange()
    {
        _ = ImmutableDictionary.CreateRange(data.Select(x => new KeyValuePair<int, int>(x, x)));
    }

    [Benchmark]
    public void Initialization_ImmutableDictionary()
    {
        _ =  data.ToImmutableDictionary(x => x, x => x);
    }

    [Benchmark]
    public void Initialization_FrozenDictionary()
    {
        _ = data.ToFrozenDictionary(x => x, x => x);
    }

    [Benchmark]
    public void TryGetValue_Reads_Dictionary()
    {
        foreach (int key in shuffled_data)
            _ = dictionary.TryGetValue(key, out int value);
    }

    [Benchmark]
    public void TryGetValue_Reads_ImmutableDictionary()
    {
        foreach (int key in shuffled_data)
            _ = immutableDictionary.TryGetValue(key, out int value);
    }

    [Benchmark]
    public void TryGetValue_Reads_FrozenDictionary()
    {
        foreach (int key in shuffled_data)
            _ = frozen_dictionary.TryGetValue(key, out int value);
    }

    [Benchmark]
    public void Indexers_Reads_Dictionary()
    {
        foreach (int key in shuffled_data)
            _ = dictionary[key];
    }

    [Benchmark]
    public void Indexers_Reads_ImmutableDictionary()
    {
        foreach (int key in shuffled_data)
            _ = immutableDictionary[key];
    }

    [Benchmark]
    public void Indexers_Reads_FrozenDictionary()
    {
        foreach (int key in shuffled_data)
            _ = frozen_dictionary[key];
    }
}