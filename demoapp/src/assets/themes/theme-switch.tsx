import { FC, useContext } from "react";
import { ThemeContext } from "./theme-context";
import styled from "styled-components";

const SwitchContainer = styled.label`
    position: relative;
    float:right;
    display: inline-block;
    width: 45px;
    height: 25px;

    & input {
        opacity:0;
        width:0;
        height:0;
    }
`;

const Slider=styled.div`
    position: absolute;
    cursor: pointer;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: #ccc;
    -webkit-transition: .4s;
    transition: .4s;
    border-radius: 34px;

    &:before{
        position: absolute;
        content: "";
        height: 21px;
        width: 21px;
        left: 2px;
        bottom: 2px;
        background-color: white;
        -webkit-transition: .4s;
        transition: .4s;
        border-radius: 50%;
    }
`

const Input=styled.input.attrs({type:'checkbox'})`
    &:checked + ${Slider}{
        background-color: #2196F3;
    }
    &:focus + ${Slider}{
        box-shadow: 0 0 1px #2196F3;
    }
    &:checked + ${Slider}:before {
        -webkit-transform: translateX(26px);
        -ms-transform: translateX(26px);
        transform: translateX(20px);
      }
`

const ThemeSwitch: FC =()=>{
    const {theme,setTheme}=useContext(ThemeContext);
    const switchTheme =()=>{
        const newTheme = theme === 'light'?'dark':'light';
        setTheme(newTheme);
        localStorage.setItem('theme',newTheme)
      }
    return(
        <SwitchContainer>
            <Input onChange={switchTheme} checked={theme ==='dark'}/>
            <Slider/>
        </SwitchContainer>
 );
}

export default ThemeSwitch;