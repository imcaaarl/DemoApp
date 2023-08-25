import styled from "styled-components"

export const FormContainer = styled.form`
    background-color:var(--primary-color);
    border:1px solid var(--border-color);
    height:400px;
    width:350px;
    border-radius:20px;
    box-shadow:0px 0px 10px 10px lightgrey;
    display:flex;
    flex-direction:column;
`
export const BodyWrapper = styled.div`
    height:100vh;
    width:100vw;
    position:absolute;
    display:flex;
    align-items:center;
    justify-content:center;
`

export const FormInput=styled.input`
    margin:0px 10px;
    border: 1px solid grey;
    height:25px;
    border-radius:5px;
    outline:none;

    &:focus{
        outline: 1px solid #62aae7;
    }
`

export const FlexDiv=styled.div`
    // border:1px solid black;
    margin:20px;
    flex:1;
    display:flex;
    flex-direction:column;
    // justify-content:center;
`

export const Div=styled.div`
    display:block;
    position:relative;
`

export const Title = styled.h1`
    align-self:center;
`

export const SubmitButton = styled.button`
    align-self:center;
    width:80px;
    height:30px;
    transition:transform 0.1s;

    &:hover{
        cursor:pointer;
        transform: scale(1.1,1.1);
    }
`
