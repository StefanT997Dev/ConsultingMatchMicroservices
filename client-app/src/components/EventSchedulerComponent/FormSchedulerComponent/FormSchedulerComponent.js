import React from 'react';
import './FormSchedulerComponent.css';
import ScheduledEventComponent from '../ScheduledEventComponent/ScheduledEventComponent';

const FormSchedulerComponent = (props) => (
  <div className="FormSchedulerComponent">
    <div className="formScheduler">
        <label>Enter participant's name:</label>
        <input 
        onChange={props.changeEventName}
        type="text"></input>
      
        <label>Pick a time:</label>
        <input
        onChange={props.changeEventTime}
        type="time"></input>
      
        <label>Set a date:</label>
        <input 
        onChange={props.changeEventDate}
        type="date"></input>
    
        <label>Meeting purpose:</label>
        <input
        onChange={props.changeEventPurpose}
        type="text"></input>

        <button 
        onClick={props.addEvent}
        id="buttonSubmit">Submit</button>
    </div>
    <ScheduledEventComponent
    events={props.events}
    eventName={props.eventName}
    eventTime={props.eventTime}
    eventDate={props.eventDate}
    eventPurpose={props.eventPurpose}
    />
  </div>
);

FormSchedulerComponent.propTypes = {};

FormSchedulerComponent.defaultProps = {};

export default FormSchedulerComponent;
