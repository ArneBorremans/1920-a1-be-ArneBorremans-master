﻿using System.Threading;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.ScheduledTasks.Scheduling
{
    public interface IScheduledTask
    {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
