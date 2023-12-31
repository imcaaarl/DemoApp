import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import './assets/themes/themes.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { AuthProvider } from './context/AuthProvider';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faB, faS, faCheck,faXmark } from '@fortawesome/free-solid-svg-icons';

library.add(faB,faS,faCheck,faXmark)
const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <AuthProvider>
      <App />
    </AuthProvider>
  </React.StrictMode>
);
reportWebVitals();
