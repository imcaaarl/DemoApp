import React, { PropsWithChildren, ReactNode, createContext, useContext, useState } from 'react';

interface ModalContextProps {
  showModal: (props:modalData) => void;
  hideModal: () => void;
  isModalOpen: boolean;
  modalData:any;
}

interface modalData{
  type:string;
  title:string;
  message:string;
}

const ModalContext = createContext<ModalContextProps | undefined>(undefined);

export const ModalProvider: React.FC<PropsWithChildren> = ({children}) => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [modalData, setModalData] = useState<modalData>();

  const showModal = (props:modalData) => {
    setModalData(props);
    setIsModalOpen(true);
  };

  const hideModal = () => {
    setIsModalOpen(false);
  };

  return (
    <ModalContext.Provider value={{ showModal, hideModal,isModalOpen,modalData }}>
      {children}
    </ModalContext.Provider>
  );
};

export const useModalDialog = () => {
  const context = useContext(ModalContext);
  if (!context) {
    throw new Error('useModal must be used within a ModalProvider');
  }

  return context;
};