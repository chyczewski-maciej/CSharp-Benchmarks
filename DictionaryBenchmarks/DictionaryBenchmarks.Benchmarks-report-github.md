``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1702/22H2/2022Update/SunValley2)
AMD Ryzen 7 5800X3D, 1 CPU, 16 logical and 8 physical cores
.NET SDK=8.0.100-preview.4.23260.5
  [Host] : .NET 8.0.0 (8.0.23.25905), X64 RyuJIT AVX2
  Dry    : .NET 8.0.0 (8.0.23.25905), X64 RyuJIT AVX2

Job=Dry  IterationCount=1  LaunchCount=1  
RunStrategy=ColdStart  UnrollFactor=1  WarmupCount=1  

```
|                                         Method |        N |       Mean | Error |       Gen0 |       Gen1 |      Gen2 |   Allocated |
|----------------------------------------------- |--------- |-----------:|------:|-----------:|-----------:|----------:|------------:|
|                      Initialization_Dictionary | 10000000 |   144.5 ms |    NA |          - |          - |         - | 200000952 B |
| Initialization_ImmutableDictionary_CreateRange | 10000000 | 4,601.0 ms |    NA | 12000.0000 | 11000.0000 | 1000.0000 | 560003608 B |
|             Initialization_ImmutableDictionary | 10000000 | 4,885.6 ms |    NA | 12000.0000 | 11000.0000 | 1000.0000 | 560003704 B |
|                Initialization_FrozenDictionary | 10000000 |   145.1 ms |    NA |          - |          - |         - | 200001000 B |
|                   TryGetValue_Reads_Dictionary | 10000000 |   905.9 ms |    NA |          - |          - |         - |           - |
|          TryGetValue_Reads_ImmutableDictionary | 10000000 | 6,032.7 ms |    NA |          - |          - |         - |           - |
|             TryGetValue_Reads_FrozenDictionary | 10000000 |   923.4 ms |    NA |          - |          - |         - |           - |
|                      Indexers_Reads_Dictionary | 10000000 |   897.3 ms |    NA |          - |          - |         - |           - |
|             Indexers_Reads_ImmutableDictionary | 10000000 | 6,020.9 ms |    NA |          - |          - |         - |           - |
|                Indexers_Reads_FrozenDictionary | 10000000 |   910.4 ms |    NA |          - |          - |         - |           - |
