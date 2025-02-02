import { configureStore } from "@reduxjs/toolkit";
import createSagaMiddleware from "redux-saga";
import eventReducer from "./reducers/eventReducer";

const sagaMiddleware = createSagaMiddleware();

const store = configureStore(
    {
        reducer: {
            // DOdavanje reducera
            events: eventReducer,
        },
        middleware: (getDafaultMiddleware) =>
            getDafaultMiddleware(). concat(sagaMiddleware),
    }
);

sagaMiddleware.run(rootSaga);

export default store;