using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TribalWarsHubBackEnd.ScheduledTasks.Cron
{
    public delegate void CrontabFieldAccumulator(int start, int end, int interval);
}
