
internal class RateLimitter
{
    private (int limit, int current) _callsPerProductPerDay = (864000, 0);
    private (int limit, int current) _callsPerProductPerMinute = (6000, 0);
    private (int limit, int current) _callsKernelAPIPerMinute = (240, 0);
    private (int limit, int current) _callsSearchAPIPerMinute = (6000, 0);

    private DateTimeOffset lastDay;
    private DateTimeOffset lastMinute;

    private Timer _timer;

    internal RateLimitter()
    {
        var now = DateTimeOffset.Now;
        (lastDay, lastMinute) = (now, now);

        _timer = new(Tick, null, 0, 1000);
    }

    private void Tick(object? state)
    {
        var now = DateTimeOffset.Now;

        if (lastDay - now >= TimeSpan.FromDays(1))
            ResetDay(now);
        
        if (lastMinute - now >= TimeSpan.FromMinutes(1))
            ResetMinute(now);
    }

    private void ResetMinute(DateTimeOffset newDate)
    {
        lastMinute = newDate;

        _callsKernelAPIPerMinute.current = 0;
        _callsPerProductPerMinute.current = 0;
        _callsSearchAPIPerMinute.current = 0;
    }

    private void ResetDay(DateTimeOffset newDate)
    {
        lastDay = newDate;

        _callsPerProductPerDay.current = 0;
    }

    internal bool TrySendRequest(bool isKernelRequest, bool isSearchRequest)
    {
        // what other products are there except this shitty API?
        throw new NotImplementedException();
    }
}