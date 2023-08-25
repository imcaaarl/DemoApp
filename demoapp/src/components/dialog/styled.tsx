import styled from 'styled-components';

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

export const ModalContainer = styled.div`
    background-color: white;
    animation:visibility-fade-in 0.3s ease;
    height:200px;
    width:400px;
    border-radius:5px;
`

// .fade-in {
//     opacity: 0.5;
// }