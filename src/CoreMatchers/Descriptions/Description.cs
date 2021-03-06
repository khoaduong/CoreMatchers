﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JPopadak.CoreMatchers.Descriptions
{
    public class Description : IDescription
    {
        private readonly StringBuilder _builder = new StringBuilder();

        public IDescription AppendText(string text)
        {
            Append(text);
            return this;
        }

        public IDescription AppendList(string before, string separator, string after, params IDescribable[] args)
        {
            return _AppendList(before, separator, after, args);
        }

        public IDescription AppendList(string before, string separator, string after, IEnumerable<IDescribable> args)
        {
            return _AppendList(before, separator, after, args);
        }

        public IDescription AppendValueList<T>(string start, string separator, string end, IEnumerable<T> values)
        {
            return _AppendList(start, separator, end, new SelfDescribingValueEnumerable<T>(values));
        }

        public IDescription AppendValue(object value)
        {
            switch (value)
            {
                case null:
                    AppendText("null");
                    break;
                case string _:
                    EscapeValue((string)value);
                    break;
                case char _:
                    Append('"');
                    EscapeValue((char)value);
                    Append('"');
                    break;
                case short _:
                    Append("<");
                    Append(Convert.ToString(value));
                    Append("s>");
                    break;
                case long _:
                    Append("<");
                    Append(Convert.ToString(value));
                    Append("L>");
                    break;
                case float _:
                    Append("<");
                    Append(Convert.ToString(value));
                    Append("F>");
                    break;
                default:
                    AppendText("<");
                    AppendText(value.ToString());
                    AppendText(">");
                    break;
            }

            return this;
        }

        public IDescription AppendDescribable(IDescribable describable)
        {
            describable.Describe(this);
            return this;
        }

        protected void Append(string value)
        {
            _builder.Append(value);
        }

        protected void Append(char value)
        {
            _builder.Append(value);
        }

        public override string ToString()
        {
            return _builder.ToString();
        }

        private IDescription _AppendList(string start, string separator, string end, IEnumerable<IDescribable> describables)
        {
            bool separate = false;

            Append(start);
            foreach (var describable in describables)
            {
                if (separate)
                {
                    Append(separator);
                }
                AppendDescribable(describable);

                separate = true;
            }

            Append(end);
            return this;
        }

        private void EscapeValue(string value)
        {
            Append('"');
            ForEach(value, EscapeValue);
            Append('"');
        }

        /// <summary>
        /// Outputs to buffer a escaped version of special chars
        /// </summary>
        private void EscapeValue(char value)
        {
            switch (value)
            {
                case '"':
                    Append("\\\"");
                    break;
                case '\n':
                    Append("\\n");
                    break;
                case '\r':
                    Append("\\r");
                    break;
                case '\t':
                    Append("\\t");
                    break;
                case '\\':
                    Append("\\\\");
                    break;
                default:
                    Append(value);
                    break;
            }
        }

        private void ForEach<T>(IEnumerable<T> enumerable, Action<T> function)
        {
            foreach (var value in enumerable)
            {
                function(value);
            }
        }
    }
}
