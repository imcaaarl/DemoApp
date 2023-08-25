import React, { PropsWithChildren, createContext, useState } from 'react';
import { IUserAccount } from '../interface/IUserAccount';

// export interface User {
//     id: number;
//     username: string;
//     role: string;
//   }

interface AuthContextType {
  auth: any;
  setAuth: React.Dispatch<React.SetStateAction<any>>;
}

const AuthContext = createContext<AuthContextType>({
    auth:{},
    setAuth:()=>{}
});

export const AuthProvider: React.FC<PropsWithChildren> = ({ children }) => {
  const [auth, setAuth] = useState<IUserAccount|null>(null);

  return (
    <AuthContext.Provider value={{ auth, setAuth }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
