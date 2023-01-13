import {
  GET_PLAYERS_REQUEST,
  GET_PLAYERS_SUCCESS,
  GET_PLAYERS_FAILURE,
  GET_PLAYER_DETAILS_SUCCESS,
} from '../actionTypes';

const mergeArrays = (array1 = [], array2 = [], idName = '') => {
  let result = [];
  result = array1.map((element1) => {
    const match = array2.find((element2) => element1[idName] === element2[idName]);
    return {
      ...element1,
      ...match,
    };
  });
  return result;
};

const initialState = {};

function rootReducer(state = initialState, action = {}) {
  switch (action.type) {
    case GET_PLAYERS_REQUEST:
      return state;
    case GET_PLAYERS_SUCCESS:
      return action.payload;
    case GET_PLAYER_DETAILS_SUCCESS:
      // eslint-disable-next-line no-case-declarations
      const playersWithDetails = mergeArrays(state, action.payload, 'PlayerId');
      console.log(playersWithDetails);
      return playersWithDetails;
    default:
      return state;
  }
}

export default rootReducer;
