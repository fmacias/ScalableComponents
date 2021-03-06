using System;
using System.Collections.Generic;
using System.Text;

namespace fmacias.Components.EventAggregator
{
    public interface IEventSubscriptable
    {
        IEventUnsubscriber Subscribe(IEventSubscriptor subscriptor);
        List<IEventSubscriptor> GetEventSubscriptions(object triegger, string eventName);
        List<IProcessEvent> GetProcessEventSubscriptions(IProcessEvent processEvent);
        List<IEventSubscriptor> Subscriptions { get; }
        void UnsubscribeAll();
        IProcessEventFactory ProcessEventFactory { get; }
        IProcessEventSubscriptorFactory ProcessEventSubscriptorFactory { get; }
        IUIEventSubscriptorFactory UIEventSubscriptorFactory { get; }
    }
}
