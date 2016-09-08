﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPopadak.CoreMatchers.Descriptions;
using System.Text.RegularExpressions;

namespace JPopadak.CoreMatchers.Matchers
{
    public class DescribedAs : Matcher
    {
        private readonly static Regex ARG_PATTERN = new Regex("{([0-9]+)}");
        private readonly string _descriptionTemplate;
        private readonly Matcher _matcher;
        private readonly object[] _args;

        public DescribedAs(string descriptionTemplate, Matcher matcher, object[] values)
        {
            _descriptionTemplate = descriptionTemplate;
            _matcher = matcher;
            _args = new object[values.Length];

            Array.Copy(values, _args, values.Length);
        }

        public override bool Matches(object actual)
        {
            return _matcher.Matches(actual);
        }

        public override void Describe(IDescription description)
        {
            MatchCollection matches = ARG_PATTERN.Matches(_descriptionTemplate);

            int textStart = 0;
            foreach (Match match in matches)
            {
                // Add the description
                string subStr = _descriptionTemplate.Substring(textStart, match.Index - textStart);
                description.AppendText(subStr);

                // Add the value of the description
                int argIndex = getIndex(match);
                description.AppendValue(_args[argIndex]);

                // Move our new start location
                textStart = match.Index + match.Length;
            }
            
            if (textStart < _descriptionTemplate.Length)
            {
                string postLength = _descriptionTemplate.Substring(textStart);
                description.AppendText(postLength);
            }
        }

        public override void DescribeMismatch(object actual, IDescription description)
        {
            _matcher.DescribeMismatch(actual, description);
        }

        private int getIndex(Match match)
        {
            GroupCollection groups = match.Groups;
            string argIndex = groups[1].Value;
            return Int32.Parse(argIndex);
        }
    }
}
