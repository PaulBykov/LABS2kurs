using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    public interface IFormatter
    {
        SerializationBinder Binder { get; set; }
        StreamingContext Context { get; set; }
        ISurrogateSelector SurrogateSelector { get; set; }
        object Deserialize(Stream serializationStream);
        void Serialize(Stream serializationStream, object graph);
    }

}
