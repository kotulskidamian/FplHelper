import { call, put, takeEvery } from 'redux-saga/effects';
import { GET_PLAYERS_REQUEST } from '../actionTypes';
import { getPlayers, getPlayersSuccess, getPlayersFailure } from '../actions';

function* workGetPlayers() {
  try {
    const players = yield call(getPlayers);
    console.log(players);
    yield put(getPlayersSuccess(players));
  } catch (e) {
    yield put(getPlayersFailure(e.message));
  }
}

function* sagas() {
  yield takeEvery(GET_PLAYERS_REQUEST, workGetPlayers);
}

export default sagas;
