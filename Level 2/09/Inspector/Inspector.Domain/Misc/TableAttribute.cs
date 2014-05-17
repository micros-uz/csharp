using System;

namespace Inspector.Domain.Misc
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public TableAttribute(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; set; }
    }
}
