using System;

namespace Domain
{
    public class ErrorField
    {
        public string PropertyName { get; set; }
        public string Error { get; set; }
        public Exception Exception { get; set; }
    }
}
