import { FC } from 'react'
import {Route,Routes} from 'react-router-dom'
import Login from '../pages/login/Login'
import Home from '../pages/home/Home'
import Registration from '../pages/login/Registration'
import Layout from '../components/layout/Layout'
import NotFound from '../pages/NotFound'
import RequireAuth from '../pages/login/RequireAuth'
import { type } from 'os'

// const ROLES={
//     'User':'User',
//     'Admin':'Administrator',
// }
interface RoutesProps {
    isAuthenticated: boolean;
  }
const MyRoutes: FC<RoutesProps> = ({ isAuthenticated })=>{
    return(
        <Routes>
            <Route path="/" element={<Layout />}>
                {/* Public Routes */}
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Registration />} />

                {/* Private Routes */}
                <Route element={<RequireAuth allowedRoles={[{role:2001,type:1001}]}/>}>
                    <Route path="/" element={<Home />} />
                </Route>

                {/* All */}
                <Route path="*" element={<NotFound />} />
            </Route>
        </Routes>
    )
}

export default MyRoutes;