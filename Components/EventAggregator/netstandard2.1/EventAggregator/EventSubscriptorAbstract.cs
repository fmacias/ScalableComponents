using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace fmacias.Components.EventAggregator
{
    public abstract class EventSubscriptorAbstract: IEventSubscriptor
    {
        protected object trieggerEventSource;
        protected EventInfo eventInfo;
        protected Delegate handler;
        protected IEventUnsubscriber unsubscriber;
        protected string eventName;
        
        protected EventSubscriptorAbstract(IEventSubscriptable eventAggregator)
        {
            unsubscriber = eventAggregator.Subscribe(this);
        }

        public string EventName => eventInfo.Name;

        public object TrieggerObject => trieggerEventSource;

        public IEventUnsubscriber Unsubscriber => unsubscriber;

        /// <summary>
        /// Allow only one event for each subscriber.
        /// To attach two EventHandlers, create other subscriber with the same object.
        /// </summary>
        /// <typeparam name="TDelegate"></typeparam>
        /// <param name="handler"></param>
        /// <returns></returns>
        protected IEventSubscriptor AddEventHandler<TDelegate>(TDelegate handler)
        {
            if (eventInfo == null)
            {
                eventInfo = trieggerEventSource.GetType().GetEvent(eventName);
                this.handler = handler as Delegate;
                eventInfo.AddEventHandler(trieggerEventSource, this.handler);
            }
            return this;
        }
        public void Unsubscribe()
        {
            if (!(eventInfo == null))
                eventInfo.RemoveEventHandler(trieggerEventSource, this.handler);

            unsubscriber.Dispose();
        }
    }
}
