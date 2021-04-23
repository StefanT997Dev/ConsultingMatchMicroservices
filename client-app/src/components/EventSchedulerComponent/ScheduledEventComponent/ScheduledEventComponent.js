import React from 'react';
import PropTypes from 'prop-types';
import './ScheduledEventComponent.css';

const ScheduledEventComponent = (props) => (
  <div className="ScheduledEventComponent">
     <div className="event-container">
       {props.events.map(event=>
        <div className="eventCard">
        <div className="nameSection">
          <p className="bela name">{props.eventName}</p>
        </div>
        <div className="timeAndDateSection">
          <p className="bela time">{props.eventTime}</p>
          <p className="bela date">{props.eventDate}</p>
        </div>
        <div className="meetingPurposeSection">
          <p className="bela business">{props.eventPurpose}</p>
        </div>
      </div>
       )}
      </div>
  </div>
);

ScheduledEventComponent.propTypes = {};

ScheduledEventComponent.defaultProps = {};

export default ScheduledEventComponent;
