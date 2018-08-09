using Xunit;
using System;
using System.Collections.Generic;
using riminder.response;
using Newtonsoft.Json;


namespace riminder.UnitTests
{
    public class RequestUtils_Test
    {
        class IsEmptyTest
        {
            public string value;
            public bool expected_result;

            public IsEmptyTest(string value, bool expected_result)
            {
                this.value = value;
                this.expected_result = expected_result;
            }
        }

        class AddIfNotNullTest<T>
        {
            public Dictionary<string, T> to_fill;
            public string key;
            public T value;
            public Dictionary<string, T> expected_result;

            public AddIfNotNullTest( Dictionary<string, T> to_fill, string key, T value,  Dictionary<string, T> expected_result)
            {
                this.to_fill = to_fill;
                this.key = key;
                this.value = value;
                this.expected_result = expected_result;
            }
        }

        private Dictionary<string, IsEmptyTest> _isEmptyTests; 
        private Dictionary<string, AddIfNotNullTest<string>> _strAddIfNotNullTest;
        private Dictionary<string, AddIfNotNullTest<object>> _objAddIfNotNullTest;

        public RequestUtils_Test()
        { 
            _isEmptyTests = new Dictionary<string, IsEmptyTest>
            {
                {"Filled String", new IsEmptyTest("here", false)},
                {"Null string", new IsEmptyTest(null, true)},
                {"Empty string", new IsEmptyTest("", true)}
            };
            _strAddIfNotNullTest = new Dictionary<string, AddIfNotNullTest<string>>
            {
               { "Normal value", new AddIfNotNullTest<string>(
                   to_fill: new Dictionary<string, string>
                   {
                       {"something", "something"}
                   },
                   key: "pomme",
                   value: "rouge",
                   expected_result: new Dictionary<string, string>
                   {
                       {"something", "something"},
                       {"pomme", "rouge"}
                   }
               )},
               { "Null value", new AddIfNotNullTest<string>(
                   to_fill: new Dictionary<string, string>
                   {
                       {"something", "something"}
                   },
                   key: "pomme",
                   value: null,
                   expected_result: new Dictionary<string, string>
                   {
                       {"something", "something"}
                   }
               )}
            };

            // a string IS a object
            _objAddIfNotNullTest = new Dictionary<string, AddIfNotNullTest<object>>
            {
               { "Normal value", new AddIfNotNullTest<object>(
                   to_fill: new Dictionary<string, object>
                   {
                       {"something", "something"}
                   },
                   key: "pomme",
                   value: "rouge",
                   expected_result: new Dictionary<string, object>
                   {
                       {"something", "something"},
                       {"pomme", "rouge"}
                   }
               )},
               { "Null value", new AddIfNotNullTest<object>(
                   to_fill: new Dictionary<string, object>
                   {
                       {"something", "something"}
                   },
                   key: "pomme",
                   value: null,
                   expected_result: new Dictionary<string, object>
                   {
                       {"something", "something"}
                   }
               )}
            };
        }

        [Fact]
        public void Test_isEmpty()
        {
           foreach (var test in _isEmptyTests)
           {
               var res = RequestUtils.is_empty(test.Value.value);

               var mess = String.Format("{0}: expected: {1} -> got {2}", test.Key, test.Value.expected_result, res);
               Assert.True(res == test.Value.expected_result, mess);
           }
        }

        public bool is_dict_equal<T, Y>(Dictionary<T, Y> a, Dictionary<T, Y> b, bool mustEqual = true)
        {
            if (mustEqual)
            {
                if (a.Count != b.Count)
                    return false;
            }
            foreach (var item in a)
            {
                if (!b.ContainsKey(item.Key))
                    return false;
                if (!b[item.Key].Equals(item.Value))
                    return false;
            }
            return true;
        }

        [Fact]
        public void Test_addIfNotNullstrstr()
        {
            foreach (var test in _strAddIfNotNullTest)
            {
                var res = RequestUtils.addIfNotNull(ref test.Value.to_fill, 
                    test.Value.key, test.Value.value);

                var mess = String.Format("{0}: expected: {1} -> got {2}", test.Key, 
                    JsonConvert.SerializeObject(test.Value.expected_result), 
                    JsonConvert.SerializeObject(res));

                Assert.True(is_dict_equal<string, string>(res, test.Value.expected_result), mess);
            }
        }

        [Fact]
        public void Test_addIfNotNullstrobj()
        {
            foreach (var test in _objAddIfNotNullTest)
            {
                var res = RequestUtils.addIfNotNull(ref test.Value.to_fill, 
                    test.Value.key, test.Value.value);

                var mess = String.Format("{0}: expected: {1} -> got {2}", test.Key, 
                    JsonConvert.SerializeObject(test.Value.expected_result), 
                    JsonConvert.SerializeObject(res));

                Assert.True(is_dict_equal<string, object>(res, test.Value.expected_result), mess);
            }
        }
    }
}