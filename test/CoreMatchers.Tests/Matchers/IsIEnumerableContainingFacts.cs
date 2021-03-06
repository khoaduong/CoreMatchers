﻿using JPopadak.CoreMatchers.Descriptions;
using System.Collections.Generic;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsIEnumerableContainingFacts
    {
        [Fact]
        public void NullValue_Is_IsNullSafe()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = HasItem(EqualTo("irrelevant"));

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void UnknownTypeValue_Is_IsTypeSafe()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = HasItem(EqualTo("irrelevant"));

            // When
            TestHelper.AssertUnknownTypeSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void ListOfABC_HasItem_ReturnsTrue()
        {
            // Given
            List<string> actual = new List<string> { "a", "b", "c" };
            IMatcher<IEnumerable<string>> matcher = HasItem(EqualTo("a"));

            // When
            TestHelper.AssertMatches(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ListOfBCWithNoMatch_HasItem_ReturnsFalse()
        {
            // Given
            List<string> actual = new List<string> { "b", "c" };
            IMatcher<IEnumerable<string>> matcher = HasItem(new Mismatchable("a"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void ListOfBCWithNoMatch_HasItem_DescribesMismatch()
        {
            // Given
            List<string> actual = new List<string> { "b", "c" };
            IMatcher<IEnumerable<string>> matcher = HasItem(new Mismatchable("a"));

            // When
            TestHelper.AssertMismatchDescription("mismatches were: [mismatched: b, mismatched: c]", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void EmptyListWithNoMatch_HasItem_DescribesMismatch()
        {
            // Given
            List<string> actual = new List<string>();
            IMatcher<IEnumerable<string>> matcher = HasItem(new Mismatchable("a"));

            // When
            TestHelper.AssertMismatchDescription("was empty", matcher, actual);

            // Then - No Exception
        }

        [Fact]
        public void NullValue_HasItem_ReturnsFalse()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = HasItem(EqualTo("a"));

            // When
            TestHelper.AssertDoesNotMatch(matcher, null);

            // Then - No Exception
        }

        [Fact]
        public void CollectionOfMismatchable_HasItem_ShowsReadableDescription()
        {
            // Given
            IMatcher<IEnumerable<string>> matcher = HasItem(new Mismatchable("a"));

            // When
            TestHelper.AssertDescription("an enumerable containing mismatchable: a", matcher);

            // Then - No Exception
        }

        [Fact]
        public void CollectinHoldingSuperclass_HasItem_ReturnsTrue()
        {
            // Given.
            HashSet<SampleBaseClass> hashSet = new HashSet<SampleBaseClass> { new SampleBaseClass("value") };
            IMatcher<IEnumerable<SampleBaseClass>> matcher = HasItem<SampleBaseClass>(EqualTo(new SampleSubClass("value")));

            // When
            TestHelper.AssertMatches(matcher, hashSet);

            // Then - No Exception
        }


        private class Mismatchable : TypeSafeDiagnosingMatcher<string>
        {
            private readonly string value;

            public Mismatchable(string value)
            {
                this.value = value;
            }

            protected override bool MatchesSafely(string item, IDescription mismatchDescription)
            {
                if (value.Equals(item))
                {
                    return true;
                }
                mismatchDescription.AppendText("mismatched: " + item);
                return false;
            }

            public override void Describe(IDescription description)
            {
                description.AppendText("mismatchable: " + value);
            }
        }
    }
}