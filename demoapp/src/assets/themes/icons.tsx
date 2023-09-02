import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import styled from "styled-components";

const StyledSuccessIcon = styled(FontAwesomeIcon)`
    font-size:70px;
    color:var(--mc-success);
    animation: bounce 0.5s;
`
const StyledErrorIcon = styled(FontAwesomeIcon)`
    font-size:70px;
    color:var(--mc-danger);
    animation: shake 0.5s;
    
`
export const SuccessIcon = ()=>{
    return(
        <StyledSuccessIcon icon={["fas","check"]}/>
    );
}

export const ErrorIcon = ()=>{
    return(
        <StyledErrorIcon icon={["fas","xmark"]}/>
    );
}