import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux"

const EventList = () => {
    const dispatch = useDispatch();
    const events = useSelector(state => state.events);

    useEffect(() => {
        dispatch(fetchEvents());
    }, [dispatch]);

    return (
        <div>
            <h1>Dogadjaji</h1>
            {events.map(event => (
                <div key={event.id}>
                    <h2>{event.name}</h2>
                    <p>{event.description}</p> 
                </div>
            ))}
        </div>
    )
}

export default EventList;