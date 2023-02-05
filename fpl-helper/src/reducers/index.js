import {
  INIT_GET_PLAYERS,
  GET_PLAYERS_REQUEST,
  GET_PLAYERS_SUCCESS,
  GET_PLAYERS_FAILURE,
  GET_PLAYER_DETAILS_SUCCESS,
  GET_PLAYER_DETAILS_FAILURE,
  GET_PLAYER_STATS_SUCCESS,
  GET_PLAYER_STATS_FAILURE,
  GET_TEAMS_SUCCESS,
  GET_TEAMS_FAILURE,
  GET_POSITIONS_SUCCESS,
  GET_POSITIONS_FAILURE,
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

const fixStatsTypes = players => {
  let result = [];
  result = players.map(player => {
    player.selectedByPercent = +player.selectedByPercent;
    player.valueSeason = +player.valueSeason;
    player.expectedGoals = +player.expectedGoals;
    player.expectedAssists = +player.expectedAssists;

    return player;
  });
  return result;
};

const setupTeamForPlayers = (players, teams) => {
  let result = [];
  result = players.map(player => {
    player.teamName = teams.find(team => team.id === player.teamId).name;

    return player;
  });
  return result;
};

const setupPositionForPlayers = (players, positions) => {
  let result = [];
  result = players.map(player => {
    player.positionName = positions.find(position => position.id === player.positionId).singularName;

    return player;
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
        messages: [...state.messages, 'GET_PLAYERS_SUCCESS'],
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
      fixStatsTypes(action.payload);
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
    case GET_TEAMS_SUCCESS:
      return {
        fpl: {
          players: setupTeamForPlayers(state.fpl.players, action.payload),
          teams: action.payload,
          positions: [...state.fpl.positions],
        },
        messages: [...state.messages, 'GET_TEAMS_SUCCESS'],
      };
    case GET_TEAMS_FAILURE:
      return {
        ...state,
        messages: [...state.messages, 'GET_TEAMS_FAILURE'],
      };
    case GET_POSITIONS_SUCCESS:
      return {
        fpl: {
          players: setupPositionForPlayers(state.fpl.players, action.payload),
          teams: [...state.fpl.teams],
          positions: action.payload,
        },
        messages: [...state.messages, 'GET_POSITIONS_SUCCESS'],
      };
    case GET_POSITIONS_FAILURE:
      return {
        ...state,
        messages: [...state.messages, 'GET_POSITIONS_FAILURE'],
      };
    default:
      return state;
  }
}

export default rootReducer;
