using System.Collections.Generic;
using ProtoBuf;

namespace ACE.Server.Entity.Actions
{
    [ProtoContract]
    public interface IActor
    {
        void RunActions();

        /// <summary>
        /// Returns the next action to be run
        /// </summary>
        LinkedListNode<IAction> EnqueueAction(IAction action);

        /// <summary>
        /// Not thread safe
        /// </summary>
        void DequeueAction(LinkedListNode<IAction> node);
    }
}
