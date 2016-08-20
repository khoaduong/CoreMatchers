﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.CoreMatchers.Matchers
{
    public class IsAFacts
    {
        [Fact]
        public void NullValue_IsA_IsNullSafe()
        {
            // Given
            Type actual = typeof(int);
            Matcher<Type> matcher = IsA<Type>(actual);

            // When
            TestHelper.AssertNullSafe(matcher);

            // Then - No Exception
        }

        [Fact]
        public void Int_IsA_ReturnsTrue()
        {
            // Given
            Type actual = typeof(int);
            Matcher<Type> matcher = IsA<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, 1);

            // Then - No Exception
        }

        [Fact]
        public void DoubleValue_IsA_ReturnsTrue()
        {
            // Given
            Type actual = typeof(double);
            Matcher<Type> matcher = IsA<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, 1.1);

            // Then - No Exception
        }

        [Fact]
        public void DoubleExpectedObjectActual_IsA_ReturnsFalse()
        {
            // Given
            Type actual = typeof(double);
            Matcher<Type> matcher = IsA<Type>(actual);

            // When
            TestHelper.AssertDoesNotMatch(matcher, new object());

            // Then - No Exception
        }

        [Fact]
        public void DoubleExpectedObjectActual_IsA_GivesFullClassInMismatchDescription()
        {
            // Given
            string text = "some text";
            Type actual = typeof(double);
            Matcher<Type> matcher = IsA<Type>(actual);

            // When
            TestHelper.AssertMismatchDescription("\"" + text + "\" is an instance of System.String", matcher, text);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveBoolAndTrue_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(bool);
            Matcher<Type> matcher = Any<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, true);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveByteAnd0001_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(byte);
            Matcher<Type> matcher = Any<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, (byte)1);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveCharC_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(char);
            Matcher<Type> matcher = Any<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, 'C');

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveDouble5Point0_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(double);
            Matcher<Type> matcher = Any<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, 5.0);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveFloat5Point0F_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(float);
            Matcher<Type> matcher = Any<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, 5.0f);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveInt2_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(int);
            Matcher<Type> matcher = Any<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, 2);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveLong_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(long);
            Matcher<Type> matcher = Any<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, 4L);

            // Then - No Exception
        }

        [Fact]
        public void PrimitiveDouble_Any_ReturnsTrue()
        {
            // Given
            Type actual = typeof(short);
            Matcher<Type> matcher = Any<Type>(actual);

            // When
            TestHelper.AssertMatches(matcher, (short)1);

            // Then - No Exception
        }
    }
}
