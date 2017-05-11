using Newtonsoft.Json;
using System;
using System.Reflection;

namespace WebApiCaller.Core
{
    public static class StringParser
    {
        private const string SystemNamespace = "System";

        public static bool IsSerializable<T>()
        {
            var type = typeof(T).GetTypeInfo();

            return type.IsClass && type.Namespace != SystemNamespace;
        }

        public static TOutputType ParseStringTo<TOutputType>(string input)
        {
            if (typeof(TOutputType) == typeof(string))
            {
                ChangeBase<string, TOutputType>(input);
            }

            var isSerializable = IsSerializable<TOutputType>();

            if (isSerializable)
            {
                return Deserialize<TOutputType>(input);
            }

            return ChangeBase<string, TOutputType>(input);
        }

        public static TOutputType ChangeBase<TInputType, TOutputType>(TInputType input)
        {
            return (TOutputType)Convert.ChangeType(input, typeof(TOutputType));
        }

        private static TOutputType Deserialize<TOutputType>(string input)
        {
            return JsonConvert.DeserializeObject<TOutputType>(input);
        }
    }
}