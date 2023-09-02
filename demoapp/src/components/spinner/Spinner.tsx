import styled from "styled-components";
import { Overlay } from "../commonStyled";
import { useSpinner } from "./SpinnerContext";
import { PulseLoader } from 'react-spinners';

const SpinnerContainer=styled.div`
    display: flex;
    flex-direction:column;
`

const SpinnerMessage=styled.p`
    color:white;
    animation: blink .75s infinite;
`
export const Spinner:React.FC=()=>{
    const {isSpinnerVisible} = useSpinner();
    console.log(isSpinnerVisible);

    if(!isSpinnerVisible) {
        return null;
    }

    return (
        <Overlay>
            <SpinnerContainer>
                <PulseLoader color="white"/>
                <SpinnerMessage>Loading . . .</SpinnerMessage>
            </SpinnerContainer>
        </Overlay>
    )
}

