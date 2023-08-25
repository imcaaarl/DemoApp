import axios from 'axios';
import { encryptPassword, verifyPassword } from './passwordHashSvc';
import { IUserAccount } from '../interface/IUserAccount';

interface vmResponse {
    data: {
        userAccount:IUserAccount;
        jwt:{
            token:string;
            expiresIn:number;
        }
    };
    status: string;
    message: string;
}

export const register = async (data:any) =>{
    axios.post<vmResponse>('https://localhost:3000/Register', data,
    {
        headers: {
            'Content-Type': 'application/json'
            }
        })
        .then(res => {
        })
        .catch((error)=>{
        })
}

export const login = async (data:any) =>{
    var response = await axios.post<vmResponse>('https://localhost:3000/Auth', data,
    {
        headers: {
            'Content-Type': 'application/json'
        }
    }
    )
    .then(res => {
        return res.data;
    })
    .catch((error)=>{
        var res = {"status":"Error", "message":"Unable to Login"};
        return res;
    })
    return response;
}