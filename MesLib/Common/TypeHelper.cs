using System;

namespace Common
{
    public static class TypeHelper
    {
        public static Type GetTypeByStr(string str)
        {
            switch (str)
            {
                case "string":
                    return typeof(string);

                case "DateTime":
                    return typeof(DateTime);

                case "int":
                    return typeof(int);

                case "decimal":
                    return typeof(decimal);

                case "bool":
                    return typeof(bool);

                case "byte[]":
                    return typeof(byte[]);

                case "Guid":
                    return typeof(Guid);

                default:
                    return typeof(object);
            }
        }
    }
}