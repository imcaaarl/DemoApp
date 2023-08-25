import React, { Fragment, useEffect, useState } from "react"
import { ThemeContext } from "../../assets/themes/theme-context";
import { ModalProvider } from "../dialog/ModalDialogContext";
import { ModalDialog } from "../dialog/ModalDialog";
import { Outlet } from "react-router-dom";

const Layout = ()=>{
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
    return(
        <ThemeContext.Provider value={{theme,setTheme}}>
            <ModalProvider>
                <main className='App' data-theme={theme}>
                    <Outlet/>
                    <ModalDialog />
                </main>
            </ModalProvider>
        </ThemeContext.Provider>
    );
}

export default Layout;

