import React from 'react';
import { useModalDialog } from './ModalDialogContext';
import { ModalContainer, Overlay } from './styled';

export const ModalDialog: React.FC = () => {
  const { isModalOpen, hideModal,modalData } = useModalDialog();

  if (!isModalOpen) {
    return null;
  }
//   console.log(modalData);

  return (
    <Overlay>
      <ModalContainer>
        <h2>{modalData.title}</h2>
        <p>{modalData.message}</p>
        <button onClick={hideModal}>Close</button>
      </ModalContainer>
    </Overlay>
  );
};