﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex1
{
    
    public class Bfs<T> : QueueSearcher<T>
    {

        // Ctor.
        public Bfs()
            : base()
        {
            this.numOfNodesEvaluted = 0;
        }

        /// <summary>
        /// Backtraces the shortest path and returns a list of states.
        /// </summary>
        /// <param name="finalState">The object of the final state.</param>
        /// <returns>The Solution of the algorithm.</returns>
        private Solution<T> backTrace(State<T> finalState)
        {

            Solution<T> bfsSolution = new Solution<T>();
            State<T> currState = finalState;

            // Adds the entire route to nodeList.
            while (currState != null)
            {
                bfsSolution.nodeList.Add(currState);
                currState = currState.cameFrom;
            }

            // Reverses The solution to start from the beggining.
            bfsSolution.nodeList.Reverse();
            return bfsSolution;
        }

        /// <summary>
        /// Searches for the shortest path using Bfs algorithm.
        /// </summary>
        /// <param name="searchable">The searchable object.</param>
        /// <returns>The Solution of the algorithm.</returns>
        public override Solution<T> search(ISearchable<T> searchable)
        {

            this.addToQueue(searchable.getInitialState());

            HashSet<State<T>> closed = new HashSet<State<T>>();

            // Continue until priority queue is empty.
            while (this.priorityQueue.Count() != 0)
            {

                State<T> n = this.priorityQueue.Dequeue(); // inherited from Searcher, removes the best state
                closed.Add(n);
                this.numOfNodesEvaluted++;

                // Checks if the destination was reached.
                if (n.state.ToString().Equals(searchable.getGoalState().state.ToString()))
                {
                    return this.backTrace(n);
                }

                List<State<T>> successors = searchable.getAllPossibleStates(n);

                // Iterate through all the successors and update the path.
                foreach (State<T> s in successors)
                {
                    // If not in open queue, update cameFrom and cost.
                    if (!closed.Contains(s) && !priorityQueue.Contains(s))
                    {
                        s.cameFrom = n; // set parent node.
                        s.cost = n.cost + 1; // update the cost of the path.
                        addToQueue(s);
                    }
                    // Else check if cost is cheaper and add to closed hash set.
                    else if (!closed.Contains(s) && priorityQueue.Contains(s))
                    {
                        Queue<State<T>> tempQueue = new Queue<State<T>>();
                        State<T> currState = priorityQueue.Dequeue();

                        // Find the relevant state in the priority queue.
                        while (!currState.Equals(s))
                        {
                            tempQueue.Enqueue(currState);
                            currState = tempQueue.Dequeue();
                        }

                        // Check if the cost of the current successor is cheaper than the cost of the
                        // same node in the priority queue.
                        if (s.cost < currState.cost)
                        {
                            currState = s;
                        }

                        closed.Add(priorityQueue.Dequeue());
                        this.numOfNodesEvaluted++;

                        // Return all the states back to the priority queue.
                        while (tempQueue.Count > 0)
                        {
                            priorityQueue.Enqueue(currState);
                            currState = tempQueue.Dequeue();
                        }

                    }
                }
            }

            return null;
        } 
    }
}