import { FC } from 'react'
import {Route,Routes} from 'react-router-dom'
import Login from '../pages/login/Login'
import Home from '../pages/home/Home'
import PrivateRoute from './PrivateRoutes'
import Registration from '../pages/login/Registration'

interface RoutesProps {
    isAuthenticated: boolean;
  }
const MyRoutes: FC<RoutesProps> = ({ isAuthenticated })=>{
    return(
        <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Registration />} />
            {/* <PrivateRoute
                path="/"
                isAuthenticated={isAuthenticated}
                redirectPath="/login"
            > */}
            <Route path="/" element={<Home />} />
            {/* </PrivateRoute> */}
        </Routes>
    )
}

export default MyRoutes;