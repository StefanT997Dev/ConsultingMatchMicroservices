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

  const [posts,setPosts]=useState<Post[]>([]);

  useEffect(()=>{
    axios.get('http://localhost:5000/posts')
      .then(response=>{
        setPosts(response.data.value);
      })
  },[])

  useEffect(()=>{
      consultantStore.loadConsultants();
  },[consultantStore])

  useEffect(()=>{
    axios.get('http://localhost:5000/consultants/58e5d331-ca78-4878-ac44-c3c9d0cf99fb/posts')
      .then(response=>{
        setPosts(response.data.value);
      })
  },[])
  
  return (
    <div>
         <Navbar/>
         <Container style={{marginTop:'7em'}}>
          <Route exact path='/' component={HomePage}/>
          <Route path='/login' component={LoginForm}/>
          <Route exact path='/consultants' component={ConsultantDashboard}/>
          <Route path='/profile' component={Profile}/>
          <Route path='/consultants/hire' component={Calendly}/>
         </Container>
    </div>
  );
  }

export default observer(App);
