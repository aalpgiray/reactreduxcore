﻿import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';
import { Base } from "./Base";
import { UserRole } from "../enums/UserRole";
import { Route } from "./Route";

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface UserState {
    isLoading: boolean;
    users: User[];
}

export class User extends Base {
    public userName: string;
    public name: string;
    public surname: string;
    public userRole: UserRole;
    public routes: Route[];
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestUsersAction {
    type: 'Request_Users_Action';
}

interface ReceiveUsersAction {
    type: 'Recieve_Users_Action';
    users: User[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestUsersAction | ReceiveUsersAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    getUsers: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        let fetchTask = fetch(`api/user/get`)
            .then(response => response.json() as Promise<User[]>)
            .then(users => {
                dispatch({ type: 'Recieve_Users_Action', users });
            });

        addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
        dispatch({ type: 'Request_Users_Action' });
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: UserState = { users: [], isLoading: false };

export const reducer: Reducer<UserState> = (state: UserState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'Request_Users_Action':
            return {
                users: [],
                isLoading: true
            };
        case 'Recieve_Users_Action':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                users: action.users,
                isLoading: false
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
