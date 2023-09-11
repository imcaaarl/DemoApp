import styled from "styled-components";
import { BodyWrapper, BtnSave } from "../components/commonStyled";
import { SetStateAction, useEffect, useState } from "react";
import { getRoles } from "../services/UserSvc";
import { useSpinner } from "../components/spinner/SpinnerContext";
import useRefreshToken from "../hooks/useRefreshToken";
import useAxiosPrivate from "../hooks/useAxiosPrivate";

const SelectRole = ()=>{
    const [roles,setRoles] = useState<any|null>(null);
    const [selectedRoleId, setSelectedRoleId] = useState<number|null>(null);
    const {showSpinner,hideSpinner,isSpinnerVisible} = useSpinner();
    const refresh = useRefreshToken();
    const axiosPrivate = useAxiosPrivate();

    useEffect(() => {
        showSpinner();
        (async () => {
            try {
                const response = await axiosPrivate.get('/userrole');
                if (response && response.data) { // Make sure response has data property
                    console.log(response); // Debug to see the response
                    setRoles(response.data.data); // Set roles state with data
                }
            } catch (error) {
                console.error(error); // Handle error appropriately
            } finally {
                hideSpinner(); // Make sure spinner is hidden whether there's an error or not
            }
        })();
    }, []);

    const handleClick = (roleId: number)=>{
        setSelectedRoleId(roleId);
    };
    const handleSubmit=()=>{
        console.log(selectedRoleId);
    }
    return(
        <BodyWrapper>
            <RoleSelectContainer>
                <h3>Please select role:</h3>
                <RoleUl>
                    {
                        roles?.map((role:any)=>{
                            return(
                                <RoleLi key={role.id} onClick={()=>handleClick(role.id)}>
                                    <RoleCheckBox checked={selectedRoleId===role.id}/>
                                    <RoleDescContainer>
                                        <RoleLabel>{role.role}</RoleLabel>
                                        <RoleDesc>{role.description}</RoleDesc>
                                    </RoleDescContainer>
                                </RoleLi>
                            )
                        })
                    }
                </RoleUl>
                <BtnSave onClick={handleSubmit}>Submit</BtnSave>
                <button onClick={refresh}></button>
            </RoleSelectContainer>
        </BodyWrapper>
    );
}

export default SelectRole;

const RoleSelectContainer = styled.div`
    width:40rem;
    height:50vh;
    display:flex;
    align-items:center;
    flex-direction:column;
    padding:10px;
    /* background-color:grey; */
    border-radius:5px;
    box-shadow: 0 0 5px lightgray;
    overflow-y:auto;
`
const RoleUl = styled.ul`
    list-style:none;
`
const RoleLi = styled.li`
    /* border:1px solid grey; */
    box-shadow:0 0 2px black;
    width:350px;
    height:45px;
    text-align:center;
    padding:5px 15px;
    margin:10px;
    display:flex;
    cursor:pointer;
    border-radius:5px;
    transition:background-color 0.1s;

    &:hover{
        background-color:#f7f7f7;
    }
`
const RoleCheckBox=styled.input.attrs({type: 'radio',})`
    transform:scale(1.4);
    cursor: pointer;
`
const RoleDescContainer=styled.div`
    margin:0 0 0 15px;
    width:100%;
    text-align:start;
`
const RoleDesc=styled.p`
    margin:0;
`
const RoleLabel = styled.label`
    font-weight:bold;
    font-size:18px;
    cursor:pointer;
`