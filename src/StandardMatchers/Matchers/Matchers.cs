using System.Collections.Generic;
using JPopadak.CoreMatchers.Matchers;
using JPopadak.StandardMatchers.Matchers.Collections;
using static JPopadak.CoreMatchers.Matchers.Matchers;

namespace JPopadak.StandardMatchers.Matchers
{
    public static class Matchers
    {
        /// <summary>
        /// Creates a matcher that matches the dictionary's size against the given matcher.
        /// </summary>
        public static IMatcher<IDictionary<TKey, TValue>> DictionaryWithSize<TKey, TValue>(IMatcher<int> sizeMatcher)
        {
            return new IsDictionaryWithSize<TKey, TValue>(sizeMatcher);
        }

        /// <summary>
        /// Creates a matcher that matches the dictionary's size against the given size.
        /// </summary>
        public static IMatcher<IDictionary<TKey, TValue>> DictionaryWithSize<TKey, TValue>(int size)
        {
            return new IsDictionaryWithSize<TKey, TValue>(new IsEqual<int>(size));
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one entry
        /// whose key satisfies the specified keyMatcher <b>and</b> whose value satisfies the specified valueMatcher.
        /// For example:
        /// <code>Assert.That(myDictionary, HasEntry(EqualTo("bar"), EqualTo("foo")))</code>
        /// </summary>
        ///
        /// <param name="keyMatcher">
        ///     The key matcher that, in combination with the valueMatcher, must be satisfied by at least one entry.
        /// </param>
        /// <param name="valueMatcher">
        ///     The value matcher that, in combination with the keyMatcher, must be satisfied by at least one entry.
        /// </param>
        public static Matcher<IDictionary<TKey, TValue>> HasEntry<TKey, TValue>(IMatcher<TKey> keyMatcher, IMatcher<TValue> valueMatcher)
        {
            return new IsDictionaryContaining<TKey, TValue>(keyMatcher, valueMatcher);
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one entry
        /// whose key equals the specified key <b>and</b> whose value equals the specified value.
        /// For example:
        /// <code>Assert.That(myDictionary, HasEntry(EqualTo("bar"), EqualTo("foo")))</code>
        /// </summary>
        ///
        /// <param name="key">The key that, in combination with the value, must describe at least one entry.</param>
        /// <param name="value">The value that, in combination with the key, must describe at least one entry.</param>
        public static Matcher<IDictionary<TKey, TValue>> HasEntry<TKey, TValue>(TKey key, TValue value)
        {
            return new IsDictionaryContaining<TKey, TValue>(EqualTo(key), EqualTo(value));
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one key
        /// that satisfies the specified matcher.
        /// </summary>
        ///
        /// <param name="keyMatcher">The matcher that must be satisfied by at least one key.</param>
        public static Matcher<IDictionary<TKey, TValue>> HasKey<TKey, TValue>(IMatcher<TKey> keyMatcher)
        {
            return new IsDictionaryContaining<TKey, TValue>(keyMatcher, Anything<TValue>());
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one key
        /// that equals the specified key.
        /// </summary>
        ///
        /// <param name="key">The key that satisfying IDictionarys must contain</param>
        public static Matcher<IDictionary<TKey, TValue>> HasKey<TKey, TValue>(TKey key)
        {
            return new IsDictionaryContaining<TKey, TValue>(EqualTo(key), Anything<TValue>());
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one value
        /// that satisfies the specified matcher.
        /// </summary>
        ///
        /// <param name="valueMatcher">The matcher that must be satisfied by at least one value.</param>
        public static Matcher<IDictionary<TKey, TValue>> HasValue<TKey, TValue>(IMatcher<TValue> valueMatcher)
        {
            return new IsDictionaryContaining<TKey, TValue>(Anything<TKey>(), valueMatcher);
        }

        /// <summary>
        /// Creates a matcher for IDictionarys matching when the examined IDictionary contains at least one value
        /// that equals the specified value.
        /// </summary>
        ///
        /// <param name="value">The key that satisfying IDictionarys must contain</param>
        public static Matcher<IDictionary<TKey, TValue>> HasValue<TKey, TValue>(TValue value)
        {
            return new IsDictionaryContaining<TKey, TValue>(Anything<TKey>(), EqualTo(value));
        }

        /// <summary>
        /// Creates a matcher for Iterables matching examined
        /// iterables that yield no items.
        /// For example:
        /// <code>Assert.That(new List&lt;String&gt;(), Is(EmptyEnumerable()))</code>
        /// </summary>
        public static IMatcher<IEnumerable<T>> EmptyEnumerable<T>()
        {
            return new IsEmptyEnumerable<T>();
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that matches when a single pass over the examined Enumerable yields
        /// an item count that satisifes the specified matcher.
        /// For example:
        /// <code>Assert.That(new List&lt;string&gt; {"foo", "bar"}, EnumerableWithSize(EqualTo(2)))</code>
        /// </summary>
        /// <param name="sizeMatcher">A matcher for the number of items that should be yielded by an examined IEnumerable.</param>
        public static IMatcher<IEnumerable<T>> EnumerableWithSize<T>(IMatcher<int> sizeMatcher)
        {
            return new IsEnumerableWithSize<T>(sizeMatcher);
        }

        /// <summary>
        /// Creates a matcher for IEnumerables that matches when a single pass over the examined Enumerable yields
        /// an item count that is equal to the specified size argument.
        /// For example:
        /// <code>Assert.That(new List&lt;string&gt; {"foo", "bar"}, EnumerableWithSize(2))</code>
        /// </summary>
        /// <param name="size">The number of items that should be yielded by an examined IEnumerable.</param>
        public static IMatcher<IEnumerable<T>> EnumerableWithSize<T>(int size)
        {
            return new IsEnumerableWithSize<T>(EqualTo(size));
        }
    }
}