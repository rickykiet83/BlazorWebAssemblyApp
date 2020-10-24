using System;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorProducts.Client.Components
{
    public partial class CounterPrint: IDisposable
    {
        [Parameter]
        public int CurrentCount { get; set; }

        [Parameter]
        public string Title { get; set; }
        
        [Inject]
        public ILogger<CounterPrint> Logger { get; set; }

        private void CreateLogs()
        {
            var logLevels = Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>();

            foreach (var logLevel in logLevels.Where(l => l != LogLevel.None))
            {
                Logger.Log(LogLevel.Information, logLevel.ToString());
            }
        }
        
        protected override void OnInitialized()
        {
            CreateLogs();
            Logger.Log(LogLevel.Information,$"OnInitialized => Title: {Title}, CurrentCount: {CurrentCount}");
        }

        protected override void OnParametersSet()
        {
            Logger.Log(LogLevel.Information,$"OnParametersSet => Title: {Title}, CurrentCount: {CurrentCount}");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
                Logger.Log(LogLevel.Information,"This is the first render of the component");
        }

        protected override bool ShouldRender()
        {
            return true;
        }

        public void Dispose()
        {
            Logger.Log(LogLevel.Information,"Component removed from the parnet's render tree");
        }
    }
}