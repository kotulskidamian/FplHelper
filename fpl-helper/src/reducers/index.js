import { GET_PLAYERS_REQUEST, GET_PLAYERS_SUCCESS, GET_PLAYERS_FAILURE } from '../actionTypes';

const initialState = {};

function rootReducer(state = initialState, action = {}) {
  switch (action.type) {
    case GET_PLAYERS_REQUEST:
      return state;
    case GET_PLAYERS_SUCCESS:
      return action.payload;
    default:
      return state;
  }
}

export default rootReducer;
