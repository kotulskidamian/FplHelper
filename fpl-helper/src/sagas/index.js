import { call, put, takeEvery } from 'redux-saga/effects';
import { GET_PLAYERS_REQUEST } from '../actionTypes';
import {
  getPlayers,
  getPlayersSuccess,
  getPlayersFailure,
  getPlayerDetails,
  getPlayerDetailsSuccess,
} from '../actions';

function* workGetPlayers() {
  try {
    const players = yield call(getPlayers);
    yield put(getPlayersSuccess(players));

    const playerDetails = yield call(getPlayerDetails);
    yield put(getPlayerDetailsSuccess(playerDetails));
  } catch (e) {
    yield put(getPlayersFailure(e.message));
  }
}

function* sagas() {
  yield takeEvery(GET_PLAYERS_REQUEST, workGetPlayers);
}

export default sagas;
