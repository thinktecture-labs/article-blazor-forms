using System;
using System.Timers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blazor.FormSample.Web.Components.Performance
{
    public partial class PerformanceTextArea
    {
        private int _valueHashCode = 0;
        private bool _enablePerformance = false;
        [Parameter] public string Value { get; set; }

        protected override bool ShouldRender()
        {
            if (_enablePerformance)
            {
                var lastHashCode = _valueHashCode;
                _valueHashCode = String.IsNullOrWhiteSpace(Value)
                    ? 0
                    : Value.GetHashCode();
                return _valueHashCode != lastHashCode;
            }

            return base.ShouldRender();
        }

        private void OnValueChanged(string obj)
        {
            Value = obj;
        }
    }
}