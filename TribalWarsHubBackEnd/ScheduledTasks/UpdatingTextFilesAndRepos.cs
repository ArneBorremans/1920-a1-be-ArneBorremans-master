using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Data;
using TribalWarsHubBackEnd.ScheduledTasks.Scheduling;

namespace TribalWarsHubBackEnd.ScheduledTasks
{
    public class UpdatingTextFilesAndRepos : IScheduledTask
    {
        public string Schedule => "0 */1 * * *";

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Updating");
        }
    }
}
