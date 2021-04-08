using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace Blazor.FormSample.Web.Components.Performance
{
    public partial class PerfInputText
    {
        [Parameter] public string Id { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool EnablePerformanceBoost { get; set; }
        [Parameter] public Expression<Func<string>> ValidationFor { get; set; }

        private int _valueHashCode;

        protected override bool ShouldRender()
        {
            if (!EnablePerformanceBoost)
                return base.ShouldRender();

            var lastHashCode = _valueHashCode;
            _valueHashCode = Value?.GetHashCode() ?? 0;
            return _valueHashCode != lastHashCode;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            Console.WriteLine("OnAfterRender called...");
            base.OnAfterRender(firstRender);
        }

        protected override bool TryParseValueFromString(string value, out string result,
            out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}