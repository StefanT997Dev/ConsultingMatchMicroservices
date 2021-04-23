import React from 'react';

const LoginComponent = (props) => (
  <div className="LoginComponent">
    <label>Enter your name</label>
      <input 
        type="text" 
        name="clientName"
        onChange={props.changeHandler}
      />
      <br/>
      <button className="btn btn-primary" onClick={props.createAClient}>Create client</button>
      <br/>

      <button className="btn btn-primary" onClick={props.getClientsFromUsa}>Get clients from USA</button>
      
      {props.clients.map((client)=>(
        <li key={client.id}>{client.name} {client.surname}</li>
      ))}
  </div>
);

LoginComponent.propTypes = {};

LoginComponent.defaultProps = {};

export default LoginComponent;
