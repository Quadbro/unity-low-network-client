namespace Game.Core.EventManager {

    public class DefaultEvent : IEvent {

        public DefaultEvent () {
        }

        public System.Collections.ArrayList GetData () {
            return new System.Collections.ArrayList();
        }
    }
}