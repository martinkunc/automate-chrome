using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChromeAutomation;

namespace AutomateChrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var chrome = new Chrome("http://localhost:9222");
            
            var sessions = chrome.GetAvailableSessions();
            
            Console.WriteLine("Available debugging sessions");
            foreach (var s in sessions)
                Console.WriteLine(s.url);

            if (sessions.Count == 0)
                throw new Exception("All debugging sessions are taken.");
            
            // Will drive first tab session
            var sessionWSEndpoint = 
                sessions[0].webSocketDebuggerUrl;

            chrome.SetActiveSession(sessionWSEndpoint);

            chrome.NavigateTo("http://www.google.com");

            var result = chrome.Eval("document.getElementById('lst-ib').value='Hello World'");

            result = chrome.Eval("document.forms[0].submit()");

            Console.ReadLine();
        }
    }
}
