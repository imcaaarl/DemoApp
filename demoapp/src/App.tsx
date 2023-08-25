import './App.css';
import { FC, useEffect, useState } from 'react';
import { BrowserRouter, Routes } from 'react-router-dom';

import MyRoutes from './routes/Routes';

const App: FC = ()=> {
  const [isAuthenticated,setIsAuthenticated]=useState<boolean>(false);

  useEffect(()=>{
    const checkLoginStatus=()=>{
      setTimeout(()=>{
        setIsAuthenticated(false);
      },1000);
    };
    checkLoginStatus();
  },[]);

  return (
    <BrowserRouter>
      <MyRoutes isAuthenticated={false}/>
    </BrowserRouter>
      
  );
}

export default App;
