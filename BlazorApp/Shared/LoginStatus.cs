using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class LoginStatus
    {

        private bool _IsLoggedIn;

        public event Action OnLoggedIn;

        public bool IsLoggedIn
        {
            get { return _IsLoggedIn; }
            set {
                _IsLoggedIn = value;
                LoggInStausChanged();
            }
        }

        private void LoggInStausChanged()
        {
            OnLoggedIn.Invoke();
        }

    }
}
