import { FormEvent, useRef, useState } from 'react';
import { FormContainer, FlexDiv, FormInput, Title,SubmitButton } from './styled';
import { encryptPassword } from '../../services/passwordHashSvc';
import { register } from '../../services/loginSvc';
import { BodyWrapper, BtnPrimary, BtnSave } from '../../components/commonStyled';

// const USER_REGEX = /^[A-z][A-z0-9-_]{3,23}$/;
// const PWD_REGEX = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%]).{8,24}$/;
// const REGISTER_URL = '/register';
  
interface FormValues {
    FullName: string;
    Email: string;
    Role:string;
    Password: string;
  }
  
  const Registration: React.FC = () => {
    const [values, setValues] = useState<FormValues>({
      FullName: "",
      Email: "",
      Role:"",
      Password: "",
    });

    const handleSubmit = async(e: React.FormEvent<HTMLFormElement>) => {
      e.preventDefault();
      // setValues({
      //   ...values,
      //   Password:await encryptPassword(values.Password)
      // });
      register(values);
    };
  
    const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
      setValues({
      ...values,
        [e.target.name]: e.target.value,
      });
    };
  
    return (
      <BodyWrapper>
        <FormContainer onSubmit={handleSubmit}>
        <Title>Register</Title>
          <FlexDiv>
          <label htmlFor="">Full Name</label>
          <FormInput type="text" value={values.FullName} name='FullName' onChange={onChange}/>
          <label htmlFor="">Email</label>
          <FormInput type="text" value={values.Email}name='Email' onChange={onChange}/>
          <label htmlFor="">Role</label>
          <FormInput type="text" value={values.Role}name='Role' onChange={onChange}/>
          <label htmlFor="">Password</label>
          <FormInput type="password" name='Password' onChange={onChange}/>
          <hr />
          <BtnPrimary type="submit">Submit</BtnPrimary>
          </FlexDiv>
        </FormContainer>
      </BodyWrapper>
    );
  };

export default Registration;