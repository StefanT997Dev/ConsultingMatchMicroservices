import React from 'react';
import './EventSchedulerComponent.css';

const EventSchedulerComponent = (props) => (
  <div className="EventSchedulerComponent">
    <div className="flex-container">
      <div
        onClick={props.displayEventFormHandler}
        className="habits"><p>Event Scheduler</p>
      </div>
    </div>
  </div>
);

EventSchedulerComponent.propTypes = {};

EventSchedulerComponent.defaultProps = {};

export default EventSchedulerComponent;
