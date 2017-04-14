﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public interface ISearchable<T>
    {

        // Returns initial state of searchable object.
        State<T> getInitialState();

        // Returns goal state of searchable object.
        State<T> getGoalState();

        // Returns all possible states from certain state.
        List<State<T>> getAllPossibleStates(State<T> s); 

    }
}
