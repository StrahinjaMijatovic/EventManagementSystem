const initialState = {
    events: [],
};

const eventReducer = (state = initialState, action) => {
    switch (action.type) {
        case 'Fetch_EVENTS_SUCCESS':
            return {
                ...state,
                events: action.payload,
            };
        default:
            return state;
    }
};

export default eventReducer;