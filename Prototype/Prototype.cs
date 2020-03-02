using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypeUsingSerialization.Prototype
{
    [Serializable]
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;
    }

    [Serializable]
    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }
    }
}