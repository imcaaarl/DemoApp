import React from 'react'
import useAuth from './useAuth'
import axios from 'axios';

const useRefreshToken = () => {
    const { setAuth }=useAuth();

    const refresh = async ()=>{
        const response = await axios.get('/refresh',{
            withCredentials:true
        });
        setAuth((prev:any)=>{
            console.log(prev);
            console.log(response.data.jwt.token);
            return {...prev,token:response.data.jwt.token}
        });
        return response.data.jwt.token;
    }
  return refresh;
}

export default useRefreshToken;