using System;
using System.Runtime.Serialization;

namespace m0202.Exceptions
{
    [Serializable]
    public class CustomIntParserException : Exception
    {
        public CustomIntParserException()
        { }

        public CustomIntParserException(string message) : base(message)
        { }

        public CustomIntParserException(string message,
                                        Exception inner) : base(message,
                                                                inner)
        { }

        protected CustomIntParserException(SerializationInfo info,
                                           StreamingContext context) : base(info,
                                                                            context)
        { }
    }
}
