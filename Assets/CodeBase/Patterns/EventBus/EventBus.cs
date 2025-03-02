using System;

namespace CodeBase.Patterns.EventBus
{
    public class EventBus
    {
        private EventBus()
        {
        }

        private static EventBus _instance;

        public static EventBus Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EventBus();
                return _instance;
            }
        }

        public Action onSceneLoaded;

    }
}