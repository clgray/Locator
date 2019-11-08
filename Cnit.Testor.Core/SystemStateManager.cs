using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cnit.Testor.Core
{
    public static class SystemStateManager
    {
        private static bool _state;
        private static bool _isEnable;

        public static bool IsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
            }
        }

        public static event EventHandler<EventArgs> StateChanged;

        public static bool State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                if (_state == false)
                    _index = 0;
                if (StateChanged != null)
                    StateChanged(null, new EventArgs());
            }
        }

        public static bool TestState()
        {
            if (State)
                SystemMessage.ShowWarningMessage("Подождите, идёт обработка запроса.");
            return State;
        }

        private static int _index = 0;
        public static void OnStateChanged(bool state)
        {
            if (!_isEnable)
                return;
            if (state)
                _index++;
            else
                _index--;
            if (_index < 0)
                _index = 0;
            bool newState = false;
            if(_index>0)
                newState=true;
            if (_state != newState)
            {
                _state = state;
                if (StateChanged != null)
                    StateChanged(null, new EventArgs());
            }
        }
    }
}
