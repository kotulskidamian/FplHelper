import { call, all, put, takeEvery } from 'redux-saga/effects';
import { INIT_GET_PLAYERS } from '../actionTypes';
import {
  getPlayers,
  getPlayerDetails,
  getPlayerStats,
  getTeams,
  getPositions,
  getPlayersRequest,
  getPlayersSuccess,
  getPlayersFailure,
  getPlayerDetailsSuccess,
  getPlayerDetailsFailure,
  getPlayerStatsSuccess,
  getPlayerStatsFailure,
  getTeamsSuccess,
  getTeamsFailure,
  getPositionsSuccess,
  getPositionsFailure,
} from '../actions';

function* baseGetCall(getCall, actionSuccess, actionFailure) {
  try {
    const { data: result, error } = yield call(getCall);
    if (result) {
      yield put(actionSuccess(result));
    } else {
      yield put(actionFailure(error));
    }
  } catch (e) {
    console.log(`Exception in baseGetCall - ${e}`);
  }
}

function* workGetPlayers() {
  try {
    yield put(getPlayersRequest());
    yield call(baseGetCall, getPlayers, getPlayersSuccess, getPlayersFailure);

    yield all([
      call(baseGetCall, getPlayerDetails, getPlayerDetailsSuccess, getPlayerDetailsFailure),
      call(baseGetCall, getPlayerStats, getPlayerStatsSuccess, getPlayerStatsFailure),
    ]);

    yield all([
      call(baseGetCall, getTeams, getTeamsSuccess, getTeamsFailure),
      call(baseGetCall, getPositions, getPositionsSuccess, getPositionsFailure),
    ]);
  } catch (e) {
    console.log(`Exception in workGetPlayers - ${e}`);
  }
}

function* sagas() {
  yield takeEvery(INIT_GET_PLAYERS, workGetPlayers);
}

export default sagas;
