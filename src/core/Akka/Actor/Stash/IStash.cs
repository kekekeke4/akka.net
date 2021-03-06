using System;
using System.Collections.Generic;

namespace Akka.Actor
{
    /// <summary>
    /// Public interface used to expose stash capabilites to user-level actors
    /// </summary>
    public interface IStash
    {
        /// <summary>
        /// Stashes the current message (the message that the actor received last)
        /// </summary>
        void Stash();

        /// <summary>
        /// Unstash the oldest message in the stash and prepends it to the actor's mailbox.
        /// The message is removed from the stash.
        /// </summary>
        void Unstash();

        /// <summary>
        /// Unstashes all messages by prepending them to the actor's mailbox.
        /// The stash is guaranteed to be empty afterwards.
        /// </summary>
        void UnstashAll();

        /// <summary>
        /// Unstashes all messages selected by the predicate function. Other messages are discarded.
        /// The stash is guaranteed to be empty afterwards.
        /// </summary>
        void UnstashAll(Func<Envelope, bool> predicate);

        /// <summary>
        /// Returns all messages and clears the stash.
        /// The stash is guaranteed to be empty afterwards.
        /// </summary>
        IEnumerable<Envelope> ClearStash();

        void Prepend(IEnumerable<Envelope> envelopes);
    }
}