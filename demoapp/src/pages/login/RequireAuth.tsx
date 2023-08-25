import { useLocation,Navigate,Outlet } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
// import { User } from "../../context/AuthProvider";
import { FC } from "react";

interface RequireAuthProps {
    allowedRoles: {
        role:string,
    }[];
  }

const RequireAuth:FC<RequireAuthProps> = ({allowedRoles}) =>{
    const {auth}=useAuth();
    const location = useLocation();
    console.log(auth.role);
    return(
        // auth?.roles?.find((role: { role: string; })=>allowedRoles?.includes(role))?
        auth?.roles?.some((role: string) => allowedRoles.some(allowedRole => allowedRole.role === role))?
        <Outlet/>: auth?.user?
        <Navigate to="/login" state={{from:location}}/>:
        <Navigate to="/login" state={{from:location}}/>
        
    );
}

export default RequireAuth;