using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Chummer.Datastructures;
using ShadowrunEngine.ChummerInterfaces;

namespace Chummer.Skills
{ 
	class ExoticSkill : Skill
	{
		private TranslatedField<string> _specificTranslator = new TranslatedField<string>();
		private string _specific;
		private string _translated;

		//static ExoticSkill()
		//{
			
		//}
		public ExoticSkill(Character character, IXmlNode node, IFileAccess fileAccess, IXmlDocumentFactory documentFactory) : base(character, node)
		{
            IXmlNodeList exotic =
                 XmlManager.Instance.Load("weapons.xml", fileAccess, documentFactory).SelectNodes("/chummer/weapons/weapon");

            var elem = exotic.OfType<IXmlNode>()
                .Select(
                    x => new Tuple<string, string>(x["name"].InnerText, x.Attributes["translate"]?.InnerText ?? x["name"].InnerText));

            _specificTranslator.AddRange(elem);
        }

		public void Load(IXmlNode node)
		{
			_specific = node["specific"].InnerText;
			_translated = node["translated"]?.InnerText;
		}

		public override bool AllowDelete
		{
			get { return !CharacterObject.Created; }
		}

		public override int CurrentSpCost()
		{
			return BasePoints;
		}

		/// <summary>
		/// How much karma this costs. Return value during career mode is undefined
		/// </summary>
		/// <returns></returns>
		public override int CurrentKarmaCost()
		{
			return RangeCost(Base + FreeKarma(), LearnedRating);
		}

		public override bool IsExoticSkill
		{
			get { return true; }
		}

		/// <summary>
		/// Called during save to allow derived classes to save additional infomation required to rebuild state
		/// </summary>
		/// <param name="writer"></param>
		protected override void SaveExtendedData(IXmlWriter writer)
		{
			writer.WriteElementString("specific", _specific);

			if(_translated != null) writer.WriteElementString("translated", _translated);
		}

		public string Specific {
			get { return _specificTranslator.Read(_specific, ref _translated); }
			set
			{
				_specificTranslator.Write(value, ref _specific, ref _translated);
				OnPropertyChanged();
			}
		}

		public override string DisplaySpecialization
		{
			get { return Specific; }
		}
	}
}
