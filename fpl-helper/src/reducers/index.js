import {
  INIT_GET_PLAYERS,
  GET_PLAYERS_REQUEST,
  GET_PLAYERS_SUCCESS,
  GET_PLAYERS_FAILURE,
  GET_PLAYER_DETAILS_SUCCESS,
  GET_PLAYER_DETAILS_FAILURE,
  GET_PLAYER_STATS_SUCCESS,
  GET_PLAYER_STATS_FAILURE,
} from '../actionTypes';

const mergeArrays = (array1 = [], array2 = [], idName = '') => {
  let result = [];
  result = array1.map(element1 => {
    const match = array2.find(element2 => element1[idName] === element2[idName]);
    return {
      ...element1,
      ...match,
    };
  });
  return result;
};

const initialState = {
  fpl: {
    players: [],
    teams: [],
    positions: [],
  },
  messages: [],
};

function rootReducer(state = initialState, action = {}) {
  switch (action.type) {
    case INIT_GET_PLAYERS:
      return {
        fpl: {
          players: [...state.fpl.players],
          teams: [...state.fpl.teams],
          positions: [...state.fpl.positions],
        },
        messages: [...state.messages, 'INIT_GET_PLAYERS executed'],
      };
    case GET_PLAYERS_REQUEST:
      return {
        fpl: {
          players: [...state.fpl.players],
          teams: [...state.fpl.teams],
          positions: [...state.fpl.positions],
        },
        messages: [...state.messages, 'GET_PLAYERS_REQUEST sent'],
      };
    case GET_PLAYERS_SUCCESS:
      return {
        fpl: {
          players: action.payload,
          teams: [...state.fpl.teams],
          positions: [...state.fpl.positions],
        },
        messages: [...state.messages],
      };
    case GET_PLAYERS_FAILURE:
      return {
        ...state,
        messages: [...state.messages, 'GET_PLAYERS_FAILURE'],
      };
    case GET_PLAYER_DETAILS_SUCCESS:
      return {
        fpl: {
          players: mergeArrays(state.fpl.players, action.payload, 'playerId'),
          teams: [...state.fpl.teams],
          positions: [...state.fpl.positions],
        },
        messages: [...state.messages, 'GET_PLAYER_DETAILS_SUCCESS'],
      };
    case GET_PLAYER_DETAILS_FAILURE:
      return {
        ...state,
        messages: [...state.messages, 'GET_PLAYER_DETAILS_FAILURE'],
      };
    case GET_PLAYER_STATS_SUCCESS:
      return {
        fpl: {
          players: mergeArrays(state.fpl.players, action.payload, 'playerId'),
          teams: [...state.fpl.teams],
          positions: [...state.fpl.positions],
        },
        messages: [...state.messages, 'GET_PLAYER_STATS_SUCCESS'],
      };
    case GET_PLAYER_STATS_FAILURE:
      return {
        ...state,
        messages: [...state.messages, 'GET_PLAYER_STATS_FAILURE'],
      };
    default:
      return state;
  }
}

export default rootReducer;
