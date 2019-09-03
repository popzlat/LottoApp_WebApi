using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Business.Exceptions
{

    [Serializable]
    public class LotoExceptions : Exception
    {
        public string ResourceReferenceProperty { get; set; }

        public LotoExceptions()
        {
        }

        public LotoExceptions(string message)
            : base(message)
        {
        }

        public LotoExceptions(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected LotoExceptions(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ResourceReferenceProperty = info.GetString("ResourceReferenceProperty");
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            info.AddValue("ResourceReferenceProperty", ResourceReferenceProperty);
            base.GetObjectData(info, context);
        }
    }
}

