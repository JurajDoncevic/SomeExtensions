using System;
using System.Collections.Generic;
using System.Text;

namespace SomeExtensions.Functional.Tests.Mocking
{
    public class MockModel
    {
        public int Id { get; set; } = 0;
        public string Data { get; set; } = ORIGINAL_DATA;

        public static readonly string ORIGINAL_DATA = "Untouched data";
    }
}
