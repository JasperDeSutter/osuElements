using System.IO;

namespace osuElements.IO.Binary
{
    public interface IBinaryFileLine<TClass>
    {
        void ReadValue(BinaryReader binaryReader, ref TClass instance);
        void SetDefaultValue(TClass instance);
        void WriteValue(BinaryWriter writer, TClass instance);
    }
}