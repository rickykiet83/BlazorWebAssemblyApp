using System;
using Microsoft.AspNetCore.Components;
namespace BlazorProducts.Client.Components
{
    public partial class CounterPrint: IDisposable
    {
        [Parameter]
        public int CurrentCount { get; set; }

        [Parameter]
        public string Title { get; set; }
        
        protected override void OnInitialized()
        {
            Console.WriteLine($"OnInitialized => Title: {Title}, CurrentCount: {CurrentCount}");
        }

        protected override void OnParametersSet()
        {
            Console.WriteLine($"OnParametersSet => Title: {Title}, CurrentCount: {CurrentCount}");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
                Console.WriteLine("This is the first render of the component");
        }

        protected override bool ShouldRender()
        {
            return true;
        }

        public void Dispose()
        {
            Console.WriteLine("Component removed from the parnet's render tree");
        }
    }
}