// PrivateRoute.tsx
import React from 'react';
import { useNavigate, Outlet } from 'react-router-dom';

interface PrivateRouteProps {
    path:string;
    isAuthenticated: boolean;
    redirectPath: string;
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({
    path,
    isAuthenticated,
    redirectPath,
    }) => {
        const navigate = useNavigate();

        if (!isAuthenticated) {
            navigate(redirectPath);
            return null;
        }
    return (
        <Outlet/>
    );
};

export default PrivateRoute;
