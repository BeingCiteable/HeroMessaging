namespace HeroMessaging.Abstractions.Processing;

public interface IProcessorMetrics
{
    long ProcessedCount { get; }
    long FailedCount { get; }
    TimeSpan AverageDuration { get; }
}

public interface IEventBusMetrics
{
    long PublishedCount { get; }
    long FailedCount { get; }
    int RegisteredHandlers { get; }
}

public interface IQueryProcessorMetrics : IProcessorMetrics
{
    double CacheHitRate { get; }
}

public interface IQueueProcessorMetrics
{
    long TotalMessages { get; }
    long ProcessedMessages { get; }
    long FailedMessages { get; }
}

public interface IOutboxProcessorMetrics
{
    long PendingMessages { get; }
    long ProcessedMessages { get; }
    long FailedMessages { get; }
    DateTime? LastProcessedTime { get; }
}

public interface IInboxProcessorMetrics
{
    long ProcessedMessages { get; }
    long DuplicateMessages { get; }
    long FailedMessages { get; }
    double DeduplicationRate { get; }
}

public interface IProcessor
{
    bool IsRunning { get; }
}

public interface IQueueProcessor : IProcessor
{
    IQueueProcessorMetrics GetMetrics();
    Task<IEnumerable<string>> GetActiveQueues(CancellationToken cancellationToken = default);
}

public interface IOutboxProcessor : IProcessor
{
    IOutboxProcessorMetrics GetMetrics();
}

public interface IInboxProcessor : IProcessor
{
    IInboxProcessorMetrics GetMetrics();
}