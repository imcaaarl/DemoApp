import { useLocation,Navigate,Outlet } from "react-router-dom";
import useAuth from "../../hooks/useAuth";
// import { User } from "../../context/AuthProvider";
import { FC } from "react";

interface RequireAuthProps {
    allowedRoles: {
        role:number,
        type:number,
    }[];
  }

const RequireAuth:FC<RequireAuthProps> = ({allowedRoles}) =>{
    const {auth}=useAuth();
    const location = useLocation();
    const isUserRoleAllowed = allowedRoles.some(allowedRole => allowedRole.role === auth?.user.userRoleCode)||
    allowedRoles.some(allowedRole => allowedRole.type === auth?.user.userTypeCode);
    console.log(auth?.user);
    return(
        isUserRoleAllowed?
        <Outlet/>: auth?.user?
        <Navigate to="/notfound" state={{from:location}} replace/>:
        <Navigate to="/login" state={{from:location}} replace/>  
    );
}

export default RequireAuth;