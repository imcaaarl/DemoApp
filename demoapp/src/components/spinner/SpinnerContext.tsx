import { PropsWithChildren, createContext, useContext, useState } from "react";

interface SpinnerContextProps{
    showSpinner: () => void;
    hideSpinner: () => void;
    isSpinnerVisible: boolean;
}

const SpinnerContext = createContext<SpinnerContextProps|undefined>(undefined);

export const SpinnerProvider: React.FC<PropsWithChildren> = ({children})=>{
    const [isSpinnerVisible,setIsSpinnerVisible] = useState(false);
    const showSpinner = () =>{
        setIsSpinnerVisible(true);
    }
    const hideSpinner = () => setIsSpinnerVisible(false);

    return(
        <SpinnerContext.Provider value={{showSpinner,hideSpinner,isSpinnerVisible}}>
            {children}
        </SpinnerContext.Provider>
    );
}

export const useSpinner = () => {
    const context = useContext(SpinnerContext);
    if(!context){
        throw new Error("useSpinner must be used within a SpinnerProvider");
    }
    return context;
}