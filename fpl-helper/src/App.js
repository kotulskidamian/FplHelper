import React from 'react';
import { Provider } from 'react-redux';
import store from './store';
import Dashboard from './components/Dashboard';

const performTestCall = () => {};

const App = () => {
  performTestCall();

  return (
    <Provider store={store}>
      <Dashboard />
    </Provider>
  );
};

export default App;
