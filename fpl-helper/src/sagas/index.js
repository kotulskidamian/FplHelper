import { call, all, put, takeEvery } from 'redux-saga/effects';
import { INIT_GET_PLAYERS } from '../actionTypes';
import {
  getPlayers,
  getPlayerDetails,
  getPlayerStats,
  getPlayersRequest,
  getPlayersSuccess,
  getPlayersFailure,
  getPlayerDetailsSuccess,
  getPlayerDetailsFailure,
  getPlayerStatsSuccess,
  getPlayerStatsFailure,
} from '../actions';

function* getPlayerCall(playersCall, actionSuccess, actionFailure) {
  try {
    const { data: result, error } = yield call(playersCall);
    if (result) {
      yield put(actionSuccess(result));
    } else {
      yield put(actionFailure(error));
    }
  } catch (e) {
    console.log(`Exception in getPlayerCall - ${e}`);
  }
}

function* workGetPlayers() {
  try {
    yield put(getPlayersRequest());
    yield call(getPlayerCall, getPlayers, getPlayersSuccess, getPlayersFailure);

    yield all([
      call(getPlayerCall, getPlayerDetails, getPlayerDetailsSuccess, getPlayerDetailsFailure),
      call(getPlayerCall, getPlayerStats, getPlayerStatsSuccess, getPlayerStatsFailure),
    ]);
  } catch (e) {
    console.log(`Exception in workGetPlayers - ${e}`);
  }
}

function* sagas() {
  yield takeEvery(INIT_GET_PLAYERS, workGetPlayers);
}

export default sagas;
