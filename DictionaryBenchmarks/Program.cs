using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using DictionaryBenchmarks;

Summary summary = BenchmarkRunner.Run<Benchmarks>();
_ = MarkdownExporter.GitHub.ExportToFiles(summary, ConsoleLogger.Default);
