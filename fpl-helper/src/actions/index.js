import axios from 'axios';
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
import * as Utils from '../utils';

export const initGetPlayers = () => ({ type: INIT_GET_PLAYERS });

export const getPlayersRequest = () => ({ type: GET_PLAYERS_REQUEST });
export const getPlayersSuccess = (payload) => ({ type: GET_PLAYERS_SUCCESS, payload });
export const getPlayersFailure = (payload) => ({ type: GET_PLAYERS_FAILURE, payload });

export const getPlayerDetailsSuccess = (payload) => ({ type: GET_PLAYER_DETAILS_SUCCESS, payload });
export const getPlayerDetailsFailure = (payload) => ({ type: GET_PLAYER_DETAILS_FAILURE, payload });

export const getPlayerStatsSuccess = (payload) => ({ type: GET_PLAYER_STATS_SUCCESS, payload });
export const getPlayerStatsFailure = (payload) => ({ type: GET_PLAYER_STATS_FAILURE, payload });

export const getTeamsSuccess = (payload) => ({ type: GET_TEAMS_SUCCESS, payload });
export const getTeamsFailure = (payload) => ({ type: GET_TEAMS_FAILURE, payload });

export const getPositionsSuccess = (payload) => ({ type: GET_POSITIONS_SUCCESS, payload });
export const getPositionsFailure = (payload) => ({ type: GET_POSITIONS_FAILURE, payload });

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

export const getPlayerDetails = () => {
  const url = Utils.FPL_HELPER_API_BASE_URL + Utils.ENDPOINTS.PLAYER_DETAILS;

  return baseCall(url);
};

export const getPlayerStats = () => {
  const url = Utils.FPL_HELPER_API_BASE_URL + Utils.ENDPOINTS.PLAYER_STATS;

  return baseCall(url);
};

export const getTeams = () => {
  const url = Utils.FPL_HELPER_API_BASE_URL + Utils.ENDPOINTS.TEAMS;

  return baseCall(url);
};

export const getPositions = () => {
  const url = Utils.FPL_HELPER_API_BASE_URL + Utils.ENDPOINTS.POSITIONS;

  return baseCall(url);
};
