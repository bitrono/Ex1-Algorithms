﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class StatePool <T>
    {
        private Dictionary<int, State<T>> statePool;

        // Ctor.
        public StatePool()
        {
            this.statePool = new Dictionary<int, State<T>>();
        }

        /// <summary>
        /// Adds a state to the state pool.
        /// </summary>
        /// <param name="state">The state that will be added to the state pool.</param>
        public void addToStatePool(T state)
        {

            // Checks if the State already exists in pool.
            if (!this.statePool.ContainsKey(state.ToString().GetHashCode()))
            {
                this.statePool.Add(state.ToString().GetHashCode(), new State<T>(state));
            }
        }

        /// <summary>
        /// Gets a state from the state pool.
        /// </summary>
        /// <param name="state">The state that will be retrieved from the state pool.</param>
        /// <returns>The wanted state.</returns>
        public State<T> getState(T state)
        {

            if (this.statePool.ContainsKey(state.ToString().GetHashCode()))
            {
                return this.statePool[state.ToString().GetHashCode()];
            }

            return null;
        }

    }
}
