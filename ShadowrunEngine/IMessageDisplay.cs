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
    }
}
