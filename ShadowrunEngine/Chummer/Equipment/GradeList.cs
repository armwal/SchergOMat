using ShadowrunEngine.ChummerInterfaces;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Chummer.Backend.Equipment
{
	/// <summary>
	/// List of Grades for either Cyberware or Bioware.
	/// </summary>
	public class GradeList : IEnumerable<Grade>
	{
		private List<Grade> _lstGrades = new List<Grade>();

		#region Methods
		/// <summary>
		/// Fill the list of CyberwareGrades from the XML files.
		/// </summary>
		/// <param name="objSource">Source to load the Grades from, either Bioware or Cyberware.</param>
		public void LoadList(Improvement.ImprovementSource objSource, IFileAccess fileAccess, IXmlDocumentFactory documentFactory)
		{
			string strXmlFile = "";
			if (objSource == Improvement.ImprovementSource.Bioware)
				strXmlFile = "bioware.xml";
			else
				strXmlFile = "cyberware.xml";
			IXmlDocument objXMlDocument = XmlManager.Instance.Load(strXmlFile, fileAccess, documentFactory);
			
			foreach (IXmlNode objNode in objXMlDocument.SelectNodes("/chummer/grades/grade"))
			{
				Grade objGrade = new Grade();
				objGrade.Load(objNode);
				_lstGrades.Add(objGrade);
			}
		}

		/// <summary>
		/// Retrieve the Standard Grade from the list.
		/// </summary>
		public Grade GetGrade(string strGrade)
		{
			Grade objReturn = new Grade();
			foreach (Grade objGrade in _lstGrades)
			{
				if (objGrade.Name == "Standard")
				{
					objReturn = objGrade;
					break;
				}
			}

			if (strGrade != "Standard")
			{
				foreach (Grade objGrade in _lstGrades)
				{
					if (objGrade.Name == strGrade)
					{
						objReturn = objGrade;
						break;
					}
				}
			}

			return objReturn;
		}
		#endregion

		#region Enumeration Methods
		public IEnumerator<Grade> GetEnumerator()
		{
			return this._lstGrades.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		#endregion
	}
}