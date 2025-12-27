namespace HOLE.Assets.Scripts.Mods;

public class DownloadProgressEventArgs : EventArgs
{
    public int ModId;
    public string ModName;
    public long BytesReceived;
    public long TotalBytes;
    public double ProgressPercentage() => TotalBytes > 0 ? BytesReceived / (double)TotalBytes * 100 : 0;
    public double DownloadSpeed { get; set; }
    public TimeSpan EstimatedTimeRemaining { get; set; }
}

public class DownloadManager(int maxConcurrentDownloads = 3)
{
    public const int DefaultMaxConcurrentDownloads = 3;
    private readonly SemaphoreSlim _downloadSemaphore = maxConcurrentDownloads > 0 ? new SemaphoreSlim(maxConcurrentDownloads) : new SemaphoreSlim(DefaultMaxConcurrentDownloads);
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    
    public static event EventHandler<DownloadProgressEventArgs>? DownloadProgress;

    public async Task<bool> DownloadWithRetryAsync(ModDownload mod, int maxRetries = 3)
    {
        await _downloadSemaphore.WaitAsync(_cancellationTokenSource.Token);
        try
        {
            for (int attempt = 0; attempt < maxRetries; attempt++)
            {
                try
                {
                    //return await PerformDownload(mod, _cancellationTokenSource.Token);
                }
                catch (Exception ex) when (attempt < maxRetries - 1)
                {
                    Logger.Warn($"Download attempt {attempt + 1} failed: {ex.Message}. Retrying...");
                    await Task.Delay(TimeSpan.FromSeconds(Math.Pow(2, attempt)), _cancellationTokenSource.Token);
                }
            }

            return false;
        }
        finally
        {
            _downloadSemaphore.Release();
        }
    }
}