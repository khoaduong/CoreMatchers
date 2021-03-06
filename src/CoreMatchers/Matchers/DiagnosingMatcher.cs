﻿using JPopadak.CoreMatchers.Descriptions;

namespace JPopadak.CoreMatchers.Matchers
{
    public abstract class DiagnosingMatcher<T> : Matcher<T>
    {
        public sealed override bool Matches(object item)
        {
            return Matches(item, new Description());
        }
        
        public sealed override void DescribeMismatch(object item, IDescription mismatchDescription)
        {
            Matches(item, mismatchDescription);
        }

        protected abstract bool Matches(object item, IDescription mismatchDescription);
    }
}
