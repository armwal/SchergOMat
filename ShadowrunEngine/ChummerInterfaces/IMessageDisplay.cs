using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chummer
{
    public interface IMessageDisplay
    {
        void ShowError(string message, string title);
        bool AskQuestion(string message, string title);
        string AskForTextInput(string description, string limitSelection = "");
        string PickItem(Character character, string description, string forced = "", List<ListItem> generalItems = null, List<ListItem> dropDownItems = null);
        string PickSkill(Character character, string description, string limitCategory = "", string limitValue = "", string onlySkill = "");
        string PickSkillGroup(Character character, string description, string onlyGroup = "", string excludeCategory = "");
        string PickAttribute(Character character, string description, bool magEnabled, bool resEnabled, List<string> limitList, List<string> removeList, string singleAttribute);
        string PickLimit(Character character, string description, List<string> limitList, List<string> removeList, string singleLimit);
        string PickSpell(Character character, string description, string limitCategory, string forceSpellName, bool ignoreReqs);
        string PickMentorSpirit(Character character, string xmlFile, out IXmlNode bonusNode, out IXmlNode choice1BonusNode, out string choice1, out IXmlNode choice2BonusNode, out string choice2);
        string PickSide(Character character, string description, string forceValue);
        string PickText(Character character, string description, string selectedValue);
        string PickPower(Character character, string description, string limitToPowers);
        string PickOptionalPower(Character character, string description, List<KeyValuePair<string, string>> limitList, string singlePower)
    }
}
