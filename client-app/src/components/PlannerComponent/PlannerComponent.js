import React from 'react';
import PropTypes from 'prop-types';
import './PlannerComponent.css';

const PlannerComponent = (props) => (
  <div className="PlannerComponent">
    <div className="flex-container">
      <div
        onClick={props.displayPlannerHandler}
        className="habits"><p>Planner</p>
      </div>
    </div>
  </div>
);

PlannerComponent.propTypes = {};

PlannerComponent.defaultProps = {};

export default PlannerComponent;
