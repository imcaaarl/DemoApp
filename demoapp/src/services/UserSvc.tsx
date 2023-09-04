import axios from "../api/axios";
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
    var response = await axios.get('/userrole',
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