import React from "react";
import styled from "styled-components";
import NavDropDown from "./NavDropdown";
import ThemeSwitch from "../../../assets/themes/theme-switch";

const NavWrapper = styled.div`
    position:absolute;
    display:flex;
    margin: 0;
    background-color:var(--bg-color);
    height:50px;
    width:calc(100vw);
    border-bottom:1px solid grey;
    align-items:center;
`
const NavContainer = styled.div`
    flex:1;
    padding:0 1vw;
`
const NavItemContainer = styled.ul`
    margin:0;
    list-style-type:none;
`
const NavItems = styled.li<{$width?:string}>`
    width:${props=>props.$width};
    background-color:lightgrey;
    float:right;
    border-left:1px solid grey;
    
    cursor:pointer;
    & a{
        margin:10px 20px;
        display:block;
        color:black;
        text-align:center;
        text-decoration:none;
    }
`
const Logo = styled.div`
    
`
const Text=styled.h1`
    margin:0;
`

const Navbar = ()=>{
    return(
        <NavWrapper>
            <NavContainer>
                <Logo>
                    <Text>DEMO APP</Text>
                </Logo>
            </NavContainer>
            <ThemeSwitch/>
            <NavContainer>
                <NavItemContainer>
                    
                    <NavItems $width=""><a href="#logout">Logout</a></NavItems>
                    <NavItems>
                        <NavDropDown/>
                    </NavItems>
                    <NavItems><a href="#item2">Item 2</a></NavItems>
                    <NavItems><a href="#item3">Item 3</a></NavItems>
                </NavItemContainer>
            </NavContainer>
        </NavWrapper>
    )
}

export default Navbar