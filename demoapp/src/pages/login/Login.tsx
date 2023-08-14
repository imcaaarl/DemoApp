import { useState } from 'react';
import { FormContainer, BodyWrapper, FlexDiv, FormInput, Title } from './styled';
import { login } from '../../services/loginSvc';

interface FormValues {
        Email: string;
        Password: string;
      }
      
      const Login: React.FC = () => {
        const [values, setValues] = useState<FormValues>({
          Email: "",
          Password: "",
        });
    
        const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
          e.preventDefault();
          login(values);
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
            <Title>Login</Title>
              <FlexDiv>
              <label htmlFor="">Email</label>
              <FormInput type="text" value={values.Email}name='Email' onChange={onChange}/>
              <label htmlFor="">Password</label>
              <FormInput type="text" value={values.Password}name='Password' onChange={onChange}/>
              <hr />
              <button type="submit">Submit</button>
              </FlexDiv>
            </FormContainer>
          </BodyWrapper>
        );
      };


export default Login;