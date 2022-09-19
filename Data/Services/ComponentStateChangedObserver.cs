using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Data.Services
{
    public sealed class ComponentStateChangedObserver
    {
        public event Func<Task>? OnStateChanged;

        public Task NotifyStateChangedAsync() =>
            OnStateChanged?.Invoke() ?? Task.CompletedTask;
    }
}
