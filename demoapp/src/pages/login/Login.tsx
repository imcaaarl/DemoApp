import { useState } from 'react';
import { FormContainer, FlexDiv, FormInput, Title } from './styled';
import { login } from '../../services/loginSvc';
import { useNavigate,useLocation } from 'react-router-dom';
import { useModalDialog } from '../../components/dialog/ModalDialogContext';
import useAuth from '../../hooks/useAuth';
import { BodyWrapper, BtnPrimary } from '../../components/commonStyled';
import { useSpinner } from '../../components/spinner/SpinnerContext';

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

  const {showSpinner,hideSpinner,isSpinnerVisible} = useSpinner();

  const location = useLocation();
  const navigate = useNavigate();
  const from = location.state?.from?.pathname||"/";
    
  const handleSubmit = async(e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    showSpinner();
    const res = await login(values);
    console.log(res);
    

    if ('data' in res && res.status === 'Success') {
      const accessToken=res.data.jwt.token;
      const roles=[res.data.userAccount.userRoleCode];
      const user=res.data.userAccount;
      setAuth({user,roles,accessToken});
      hideSpinner();
      navigate(from, { replace: true });
    } else {
      var modalData={
        type: 'error',
        title: 'Unauthorized',
        message: 'Invalid Login details.'
        };
        hideSpinner();
      showModal(modalData);
      // navigate("/");
    }
  }

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
          setValues({
          ...values,
            [e.target.name]: e.target.value,
          });
        };
      
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

              <BtnPrimary type="submit">Submit</BtnPrimary>
              
              </FlexDiv>
            </FormContainer>
          </BodyWrapper>
        );
      };


export default Login;