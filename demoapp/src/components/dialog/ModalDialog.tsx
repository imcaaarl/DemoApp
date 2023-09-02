import React from 'react';
import { useModalDialog } from './ModalDialogContext';
import { ModalBody, ModalContainer, ModalMessage, ModalFooter, ModalHeader, ModalHeaderTitle } from './styled';
import { BtnPrimary, Overlay } from '../commonStyled';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {  ErrorIcon, SuccessIcon } from '../../assets/themes/icons';

export const ModalDialog: React.FC = () => {
  const { isModalOpen, hideModal,modalData } = useModalDialog();

  if (!isModalOpen) {
    return null;
  }

  const renderIcon=(type:string)=>{
    switch (type) {
      case'success':
        return <SuccessIcon />;
      case 'error':
        return <ErrorIcon />;
      default:
        return null;
    }
  }
//   console.log(modalData);

  return (
    <Overlay>
      <ModalContainer>
        <ModalHeader>
          <ModalHeaderTitle>{modalData.title}</ModalHeaderTitle>
        </ModalHeader>
        <ModalBody>
          {
            renderIcon(modalData.type)
          }
          <ModalMessage>{modalData.message}</ModalMessage>
        </ModalBody>
        <ModalFooter>
          <BtnPrimary onClick={hideModal}>Close</BtnPrimary>
        </ModalFooter>
      </ModalContainer>
    </Overlay>
  );
};