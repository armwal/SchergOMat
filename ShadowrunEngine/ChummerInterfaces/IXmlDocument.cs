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

    public interface IXmlNodeList : IList<IXmlNode>
    {
        IXmlNode this[int index] { get; set; }
    }

    public delegate bool TryParseFunction<T>(string input, out T result);

    public interface IXmlNode : IEnumerable
    {
        string Name { get; }
        string Value { get; }
        IXmlNode this[string key] { get; set; }
        IXmlNode Attributes { get; }
        string InnerText { get; }
        string InnerXml { get; }
        string OuterXml { get; }
        bool HasChildNodes { get; }
        IXmlNodeList ChildNodes { get; }

        IXmlNode SelectSingleNode(string path);
        IXmlNodeList SelectNodes(string path);
        
        bool TryGetField<T>(string name, out T value);
        bool TryGetField<T>(string name, out T value, T onError);
        bool TryGetField<T>(string name, TryParseFunction<T> parser, out T read);
        bool TryCheckValue(string name, string value);
    }
}
