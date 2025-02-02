import { takeEvery } from "redux-saga/effects";

function* fetchEventsSaga() {
    try {

    } catch (error) {
        console.log(error);
    }
}

export default function* rootSaga() {
    yield takeEvery('FETCH_EVENTS', fetchEventsSaga);
}