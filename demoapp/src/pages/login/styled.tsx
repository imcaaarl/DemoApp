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

export const FormInput=styled.input`
    margin:0px 10px;
    border: 1px solid grey;
    height:25px;
    border-radius:5px;
    outline:none;
    transition:outline 0.4s,border 0.2s;

    &:focus{
        box-shadow:0 0 3px var(--input-outline-color);
        border: 1px solid var(--input-outline-color);
    }
`

export const FlexDiv=styled.div`
    margin:20px;
    flex:1;
    display:flex;
    flex-direction:column;
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
