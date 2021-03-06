﻿using System;
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
        IXmlDocument DocumentElement { get; }
        string OuterXml { get; }

        void Load(string fileName);
        IXmlNode SelectSingleNode(string path);
        IXmlNodeList SelectNodes(string path);
        IXPathNavigator CreateNavigator();
        void LoadXml(string strXml);
        IXmlNode CreateElement(string path);
        void AppendChild(IXmlNode node);
        IXmlNode ImportNode(IXmlNode node, bool full);
        IXmlNode this[string name] { get; set; }
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

    public interface IXmlNode : IEnumerable<IXmlNode>
    {
        string Name { get; }
        string LocalName { get; }
        string Value { get; }
        IXmlNode this[string key] { get; set; }
        IXmlNode Attributes { get; }
        string InnerText { get; set; }
        string InnerXml { get; set; }
        string OuterXml { get; }
        bool HasChildNodes { get; }
        IXmlNodeList ChildNodes { get; }
        IXmlNode ParentNode { get; }
        IXmlDocument OwnerDocument { get; }

        IXmlNode SelectSingleNode(string path);
        IXmlNodeList SelectNodes(string path);

        void AppendChild(IXmlNode node);
        void RemoveChild(IXmlNode node);
        
        bool TryGetField<T>(string name, out T value);
        bool TryGetField<T>(string name, out T value, T onError);
        bool TryGetField<T>(string name, TryParseFunction<T> parser, out T read);
        bool TryGetField<T>(string name, TryParseFunction<T> parser, out T read, T newVal);
        bool TryCheckValue(string name, string value);

        void TryPreserveField(string name, ref bool value);

        IXmlNode Clone();
        IXPathNavigator CreateNavigator();
    }
}
