import './App.css';
import { ThemeContext } from './assets/themes/theme-context';
import { FC, useEffect, useState } from 'react';
import { BrowserRouter } from 'react-router-dom';
import MyRoutes from './routes/Routes';
import PrivateRoute from './routes/PrivateRoutes';
import Login from './pages/login/Login';

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

  const defaultDark = window.matchMedia('(prefers-color-scheme: dark)').matches;

  const getTheme = ():string=>{
    const localStorageTheme=localStorage.getItem('theme');
    const browserDefault = defaultDark?'dark':'light';
    return localStorageTheme||browserDefault;
  }

  const [theme,setTheme] = useState(getTheme());

  return (
    <BrowserRouter>
      <ThemeContext.Provider value={{theme,setTheme}}>
        <div className='App' data-theme={theme}>
        <MyRoutes isAuthenticated={isAuthenticated} />
        </div>
      </ThemeContext.Provider>
    </BrowserRouter>
      
  );
}

export default App;
