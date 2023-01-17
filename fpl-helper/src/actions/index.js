import axios from 'axios';
import {
  GET_PLAYERS_REQUEST,
  GET_PLAYERS_SUCCESS,
  GET_PLAYERS_FAILURE,
  GET_PLAYER_DETAILS_REQUEST,
  GET_PLAYER_DETAILS_SUCCESS,
  GET_PLAYER_DETAILS_FAILURE,
} from '../actionTypes';
import * as Utils from '../utils';

export const getPlayersRequest = () => ({ type: GET_PLAYERS_REQUEST });
export const getPlayersSuccess = (payload) => ({ type: GET_PLAYERS_SUCCESS, payload });
export const getPlayersFailure = (payload) => ({ type: GET_PLAYERS_FAILURE, payload });

export const getPlayerDetailsRequest = () => ({ type: GET_PLAYER_DETAILS_REQUEST });
export const getPlayerDetailsSuccess = (payload) => ({ type: GET_PLAYER_DETAILS_SUCCESS, payload });
export const getPlayerDetailsFailure = (payload) => ({ type: GET_PLAYER_DETAILS_FAILURE, payload });

// eslint-disable-next-line arrow-body-style
const baseCall = (url) => {
  return axios
    .get(url)
    .then((response) => response)
    .catch((error) => ({ error }));
};

export const getPlayers = () => {
  const url = Utils.FPL_HELPER_API_BASE_URL + Utils.ENDPOINTS.PLAYERS;

  return baseCall(url);
};

export const getTeams = () => {
  const url = Utils.FPL_HELPER_API_BASE_URL + Utils.ENDPOINTS.PLAYERS;

  return baseCall(url);
};

export const getPlayerDetails = () => {
  const url = Utils.FPL_HELPER_API_BASE_URL + Utils.ENDPOINTS.PLAYER_DETAILS;

  return baseCall(url);
};
