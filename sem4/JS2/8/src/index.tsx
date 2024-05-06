import React from 'react';
import ReactDOM from 'react-dom/client';
import './helpers/styles/index.css';
import App from './componets/screens/App/App';


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

