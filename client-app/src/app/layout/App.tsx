import React, { useState,useEffect } from 'react';
import axios from 'axios';
import { Category } from '../models/category';
import { Post } from '../models/post';
import { Container, List } from 'semantic-ui-react';
import Navbar from './Navbar';
import ConsultantDashboard from '../../features/consultants/dashboard/ConsultantDashboard';

const App =()=> {
  const [categories,setCategories]=useState<Category[]>([]);
  const [posts,setPosts]=useState<Post[]>([]);

  useEffect(()=>{
    axios.get('http://localhost:5000/posts')
      .then(response=>{
        setPosts(response.data.value);
      })
  },[])

  useEffect(()=>{
    axios.get('http://localhost:5000/categories')
      .then(response=>{
        setCategories(response.data.value);
      })
  },[])

  return (
    <div>
         <Navbar/>
         <Container style={{marginTop:'7em'}}>
           <ConsultantDashboard
              categories={categories}
              posts={posts}
           />
         </Container>
    </div>
  );
  }

export default App;
