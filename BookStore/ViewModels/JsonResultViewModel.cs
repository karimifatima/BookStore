using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.ViewModels
{
    public class JsonResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public List<ErrorObj> Errors { get; set; } = new List<ErrorObj>();
        public object CustomResult { get; set; }
        public class ErrorObj
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public string Exception { get; set; }
        }
    }
}