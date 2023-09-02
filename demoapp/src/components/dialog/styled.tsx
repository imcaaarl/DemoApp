import styled from 'styled-components';

export const ModalContainer = styled.div`
    background-color: white;
    animation:visibility-fade-in 0.3s ease;
    height:250px;
    width:400px;
    border-radius:5px;
    display:flex;
    align-items:stretch;
    flex-direction:column;
`
const flexContainer = styled.div`
    display:flex;
    align-items:center;
    justify-content:center;
`
export const ModalHeaderTitle=styled.h2 `
    margin:5px;
`
export const ModalMessage=styled.p`
    margin-top:5px;
`
export const ModalBody = styled(flexContainer)`
    flex:3;
    display:flex;
    flex-direction:column;
`
export const ModalHeader = styled(flexContainer)`
    flex:1;
`
export const ModalFooter = styled(flexContainer)`
    flex:1;
`
