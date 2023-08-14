
import styled from "styled-components";
import ThemeSwitch from '../../../assets/themes/theme-switch';

const DropdownContent = styled.div`
    display: none;
    position: absolute;
    border-radius:5px;
    background-color: #f9f9f9;
    min-width: 180px;
    box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    animation: fadeOut 0.2s;
    z-index: 1;

    & a{
        color: black;
        padding: 12px 16px;
        text-decoration: none;
        display: block;
    }
    & a:hover{
        background-color: #f1f1f1
    }
`
const DropdownContentItems=styled.div`
    margin:10px;
`
const DropdownBtn = styled.div`
    cursor: pointer;
    margin:10px 20px;
`
const DrpContainer=styled.div`
    position: relative;
    display: inline-block;

    &:hover ${DropdownContent}{
            display:block;
            animation: fadeIn 0.2s;
        }
    }
}
`
const NavDropDown = ()=>{
    return(
        <DrpContainer>
            <DropdownBtn>Settings</DropdownBtn>
            <DropdownContent>
                <DropdownContentItems>Dark Mode
                    <ThemeSwitch/>
                </DropdownContentItems>
                <hr/>
            </DropdownContent>
        </DrpContainer>
    );
}

export default NavDropDown;