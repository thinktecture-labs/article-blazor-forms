using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using Blazor.FormSample.Web.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Blazor.FormSample.Web.Services
{
    public class FormsService : IFormsService
    {
        public RenderFragment CreateComponent<T>(T data, EditContext context) => builder =>
        {
            var proList = typeof(T).GetProperties();
            foreach (var prp in proList.Where(p => p.Name != "Id"))
            {
                if (prp.GetCustomAttributes(typeof(DataTypeAttribute), false).Length != 0)
                {
                    var attrList =
                        (DataTypeAttribute) prp.GetCustomAttributes(typeof(DataTypeAttribute), false).FirstOrDefault();
                    var displayLabel =
                        (DisplayAttribute) prp.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();
                    // Get the initial property value
                    var propInfo = typeof(T).GetProperty(prp.Name);
                    // Create an expression to set the ValueExpression-attribute.
                    var constant = Expression.Constant(data, typeof(T));
                    var exp = Expression.Property(constant, prp.Name);
                    switch (attrList.DataType)
                    {
                        case DataType.Text:
                        case DataType.EmailAddress:
                        case DataType.PhoneNumber:
                        case DataType.MultilineText:
                        {
                            builder.OpenComponent(0, typeof(InputText));
                            // Create the handler for ValueChanged. I use reflection to the value.
                            builder.AddAttribute(3, "ValueChanged",
                                RuntimeHelpers.TypeCheck(EventCallback.Factory.Create(this,
                                    EventCallback.Factory.CreateInferred(this,
                                        _value =>
                                        {
                                            propInfo.SetValue(data, _value);
                                            context.NotifyFieldChanged(new FieldIdentifier(data, prp.Name));
                                        },
                                        (string) propInfo.GetValue(data)))));
                            builder.AddAttribute(4, "ValueExpression", Expression.Lambda<Func<string>>(exp));
                            if (attrList.DataType == DataType.MultilineText)
                                builder.AddAttribute(5, "Multiline", true);
                            if (attrList.DataType == DataType.EmailAddress)
                            {
                                builder.AddAttribute(5, "InputType", InputType.Email);
                            }

                            break;
                        }
                        case DataType.Date:
                            builder.OpenComponent(0, typeof(InputDate<DateTime?>));
                            var dateValue = propInfo.GetValue(data);
                            builder.AddAttribute(2, "Style", "date-picker-test");
                            builder.AddAttribute(3, "ValueChanged",
                                RuntimeHelpers.TypeCheck(EventCallback.Factory.Create(this,
                                    EventCallback.Factory.CreateInferred(this,
                                        __value => propInfo.SetValue(data, __value),
                                        (DateTime?) propInfo.GetValue(data)))));
                            builder.AddAttribute(4, "ValueExpression", Expression.Lambda<Func<DateTime?>>(exp));
                            break;
                        default:
                            Console.WriteLine($"No Component for DataType: {attrList?.DataType}");
                            continue;
                    }

                    try
                    {
                        var defaultValue = propInfo.GetValue(data);
                        builder.AddAttribute(1, "Value", defaultValue);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        builder.AddAttribute(6, "Placeholder", displayLabel?.Description ?? String.Empty);
                        builder.CloseComponent();
                    }
                }
            }
        };
    }
}