import React from 'react';
import PropTypes from 'prop-types';
import './PlannerAndRolesComponent.css';

const PlannerAndRolesComponent = (props) => (
  <div className="PlannerAndRolesComponent">
     <div className="grid-container-planner">
     <div className="rolesForm">
        <label>Purpose Driven Role #1:</label>
        <input 
        onChange={props.changeRoleOne}
        type="text"></input>
      
        <label>Purpose Driven Role #2:</label>
        <input
        onChange={props.changeRoleTwo}
        type="text"></input>
      
        <label>Purpose Driven Role #3:</label>
        <input 
        onChange={props.changeRoleThree}
        type="text"></input>
    
        <label>Purpose Driven Role #4:</label>
        <input
        onChange={props.changeRoleFour}
        type="text"></input>

        <label>Purpose Driven Role #5:</label>
        <input
        onChange={props.changeRoleFive}
        type="text"></input>
    </div>

    <div className="outcomeWhyHow">
        <div className="buttonWrapper">
          <button id="outcomeButton">Outcome?</button>
          <button id="whyButton">Why?</button>
          <button id="howButton">How?</button>
        </div>

        <label>{props.roleOne}</label>
        <input 
        type="text"></input>
      
        <label>{props.roleTwo}</label>
        <input
        type="text"></input>
      
        <label>{props.roleThree}</label>
        <input 
        type="text"></input>
    
        <label>{props.roleFour}</label>
        <input
        type="text"></input>

        <label>{props.roleFive}</label>
        <input
        type="text"></input>

        <button 
        className="marginLeft"
        id="buttonSubmit">Submit</button>
    </div>

     </div>
  </div>
);

PlannerAndRolesComponent.propTypes = {};

PlannerAndRolesComponent.defaultProps = {};

export default PlannerAndRolesComponent;
