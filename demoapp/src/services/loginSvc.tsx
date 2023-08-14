import axios from 'axios';
import { encryptPassword, verifyPassword } from './passwordHashSvc';

interface response {
    response:string | "No response",
}

export const register = async (data:any) =>{
    data.Password = await encryptPassword(data.Password);
    axios.post<response>('https://localhost:3000/Register', data,
    {
        headers: {
            'Content-Type': 'application/json'
            }
        })
        .then(res => {
            console.log(res.data);
        })
        .catch((error)=>{
            console.log(error.message);
        })
}

export const login = async (data:any) =>{

    axios.post<response>('https://localhost:3000/Auth', data,
    {
        headers: {
            'Content-Type': 'application/json'
        }
    }
    )
    .then(res => {
        console.log(res.data);
        // const isPasswordMatch = await verifyPassword(data.Password,res.data)
    })
    .catch((error)=>{
        console.log(error.message);
    })
}