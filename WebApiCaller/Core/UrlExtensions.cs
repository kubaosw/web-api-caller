using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace WebApiCaller.Core
{
    public static class UrlExtensions
    {
        public static string ToQueryString(this object request, string separator = ",")
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request is string && String.IsNullOrEmpty((string)request))
            {
                return string.Empty;
            }

            var typeInfo = request.GetType().GetTypeInfo();

            var properties = typeInfo.DeclaredProperties.Where(x => x.CanRead)
                .Where(x => x.GetValue(request, null) != null)
                .ToDictionary(x => x.Name, x => x.GetValue(request, null));

            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            foreach (var key in propertyNames)
            {
                var valueTypeInfo = properties[key].GetType().GetTypeInfo();
                var valueElemType = valueTypeInfo.IsGenericType
                                        ? valueTypeInfo.GenericTypeArguments.First()
                                        : valueTypeInfo.GetElementType();

                if (valueElemType.GetTypeInfo().IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value.ToString()))));
        }
    }
}