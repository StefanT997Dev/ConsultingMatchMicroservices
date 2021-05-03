import React, { useState,useEffect } from 'react';
import axios from 'axios';
import { Post } from '../models/post';
import { Container } from 'semantic-ui-react';
import Navbar from './Navbar';
import ConsultantDashboard from '../../features/consultants/dashboard/ConsultantDashboard';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';
import { Route } from 'react-router-dom';
import HomePage from '../../features/home/HomePage';
import LoginForm from '../../features/users/LoginForm';
import Profile from '../../features/profile/Profile';
import Calendly from './Calendly';

const App =()=> {
  const {consultantStore}=useStore();

  useEffect(()=>{
      consultantStore.loadConsultants();
      consultantStore.currentConsultants=consultantStore.consultants;
  },[consultantStore])

  return (
    <div>
         <Navbar/>
         <Container style={{marginTop:'7em'}}>
          <Route exact path='/' component={HomePage}/>
          <Route path='/login' component={LoginForm}/>
          <Route exact path='/consultants' component={ConsultantDashboard}/>
          <Route path='/profile' component={Profile}/>
          <Route path='/consultants/hire' component={Calendly}/>
          <Route path='/consultants/:id' component={Profile}/>
         </Container>
    </div>
  );
  }

export default observer(App);
