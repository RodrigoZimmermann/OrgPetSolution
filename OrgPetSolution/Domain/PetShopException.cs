using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class PetShopException : Exception
    {
        public List<ErrorField> Errors { get; private set; }
        public PetShopException(List<ErrorField> errors)
        {
            this.Errors = errors;
        }
        public string GetErrorMessage()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ErrorField error in Errors)
            {
                sb.AppendLine(error.Error);
            }
            return sb.ToString();
        }
        public PetShopException() { }
        public PetShopException(string message) : base(message) { }
        public PetShopException(string message, Exception inner) : base(message, inner) { }
        //BinaryFormatter - .Net Remoting
        protected PetShopException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
