import axios, { axiosPrivate } from "../api/axios";
import useAuth from "../hooks/useAuth";
// import useAxiosPrivate from "../hooks/useAxiosPrivate";
interface vmResponse<T>{
    data: T;
    status: string;
    message: string;
}

export interface vmRoles{
    id: number;
    role: string;
    description: string;
    userRoleCode: number;
}

export const getRoles = async () =>{
    // const axiosPrivate = useAxiosPrivate();
    // const {auth}=useAuth();
    // console.log(auth);
    var response = await axiosPrivate.get('/userrole',
    {
        headers: {
            'Content-Type': 'application/json'
            }
        })
        .then(res => {
            // console.log(res.data.data);
            return res.data.data;
        })
        .catch((error)=>{
        })
    return response;
}