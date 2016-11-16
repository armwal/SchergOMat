using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chummer
{
    public interface IXmlDocumentFactory
    {
        IXmlDocument CreateNew();
    }

    public interface IXmlDocument
    {
        void Load(string fileName);
        IXmlNode SelectSingleNode(string path);
        IXmlNodeList SelectNodes(string path);
        IXPathNavigator CreateNavigator();
        void LoadXml(string strXml);
    }

    public interface IXPathNavigator
    {
        IXPathExpression Compile(string expression);
        object Evaluate(IXPathExpression expression);
    }

    public interface IXPathExpression
    {

    }

    public interface IXmlNodeList : IEnumerable<IXmlNode>
    {
        IXmlNode this[int index] { get; set; }
    }

    public delegate bool TryParseFunction<T>(string input, out T result);

    public interface IXmlNode : IEnumerable
    {
        IXmlNode this[string key] { get; set; }
        IXmlNode Attributes { get; }
        string InnerText { get; }
        string InnerXml { get; }

        IXmlNode SelectSingleNode(string path);
        IXmlNodeList SelectNodes(string path);
        
        T TryGetField<T>(string name, out T value);
        T TryGetField<T>(string name, out T value, T onError);
        T TryGetField<T>(string name, TryParseFunction<T> parser, out T read);
    }
}
