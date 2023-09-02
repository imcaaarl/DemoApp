import styled from "styled-components";

export const Overlay = styled.div`
    position: absolute;
    background-color: rgba(0,0,0,0.5);
    // opacity: 0.5;
    top: 0;
    right: 0;
    height: 100vh;
    width: 100vw;
    display: flex;
    justify-content: center; 
    align-items: center;
    animation:bg-fade-in 0.3s ease;
    z-index: 999999;
`
export const BodyWrapper = styled.div`
    height:100vh;
    width:100vw;
    position:absolute;
    display:flex;
    align-items:center;
    justify-content:center;
`
const BtnMain = styled.button`
    cursor:pointer;
    font-size:16px;
    padding:10px 15px;
    border-radius:4px;
    border:none;
    box-shadow:0 0 3px black;
    transition:transform 0.1s linear;

    &:hover{
        transform:scale(1.04);
    }
    &:active{
        transform:scale(1);
    }
`
export const BtnSave = styled(BtnMain)`
    background-color:var(--btn-save-color);
`
export const BtnPrimary = styled(BtnMain)`
    background-color:var(--btn-primary-color);
`
export const BtnDanger = styled(BtnMain)`
    background-color:var(--btn-danger-color);
`
export const BtnWarning = styled(BtnMain)`
    background-color:var(--btn-warning-color);
`