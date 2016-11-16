using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chummer
{
    public interface IXmlWriter
    {
        Stream BaseStream { get; }

        void WriteStartDocument();
        void WriteStartElement(string name);
        void WriteEndElement();
        void WriteElementString(string name, string value);
        void WriteEndDocument();
        void Flush();
        void Close();
    }
}
