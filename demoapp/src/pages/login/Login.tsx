import { useState } from 'react';
import { FormContainer, BodyWrapper, FlexDiv, FormInput, Title,SubmitButton } from './styled';
import { login } from '../../services/loginSvc';
import { Link,useNavigate,useLocation } from 'react-router-dom';
import { useModalDialog } from '../../components/dialog/ModalDialogContext';
import useAuth from '../../hooks/useAuth';

interface FormValues {
  Email: string;
  Password: string;
  }
      
const Login: React.FC = (props) => {
  const [values, setValues] = useState<FormValues>({
    Email: "",
    Password: "",
  });
  const {setAuth} = useAuth();

  const { showModal, hideModal, isModalOpen } = useModalDialog();

  const location = useLocation();
  const navigate = useNavigate();
  const from = location.state?.from?.pathname||"/";
    
  const handleSubmit = async(e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const res = await login(values);
    console.log(res);

    if ('data' in res && res.status === 'Success') {
      const accessToken=res.data.jwt.token;
      const roles=[res.data.userAccount.userRoleCode];
      // const type=res.data.userTypeCode;
      const user=res.data.userAccount;
      setAuth({user,roles,accessToken});
      navigate(from, { replace: true });
    } else {
      var modalData={
        type: 'error',
        title: 'Unauthorized',
        message: 'Invalid Login details.'
        };
      showModal(modalData);
      navigate("/");
    }
  }
    // await login(values).then(res => {
    //     if(res.status==='Success') {
    //           console.log(res.data);
    //           // const accessToken = res
    //           // setAuth()
    //           navigate(from,{replace:true});
    //         }else{
    //           var modalData={
    //             type: 'error',
    //             title: 'Unauthorized',
    //             message: 'Invalid Login details.'
    //           };
    //           showModal(modalData);
    //           navigate("/");
    //         }
    //       });
    //     };

        const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
          setValues({
          ...values,
            [e.target.name]: e.target.value,
          });
        };

        const nav = ()=>{
          navigate("/");
        }
      
        return (
          <BodyWrapper>
            <FormContainer onSubmit={handleSubmit}>
            <Title>Login</Title>
              <FlexDiv>
              <label htmlFor="">Email</label>
              <FormInput type="text" value={values.Email} name='Email' onChange={onChange}/>
              <label htmlFor="">Password</label>
              <FormInput type="password" value={values.Password} name='Password' onChange={onChange}/>
              <hr />
              <SubmitButton type="submit">Submit</SubmitButton>
              
              </FlexDiv>
            </FormContainer>
            {/* <button onClick={showModal}>Show Modal</button>*/}
            <button onClick={nav}>go to home</button> 
          </BodyWrapper>
        );
      };


export default Login;