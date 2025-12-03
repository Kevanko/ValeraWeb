import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ValeraList from './components/ValeraList';
import ValeraStats from './components/ValeraStats';
import Login from './components/Login';
import Register from './components/Register';
import Header from './components/Header';
import { Container } from '@mui/material';

function App() {
  return (
    <BrowserRouter>
      <Header />
      <Container sx={{ mt: 3 }}></Container>
      <Routes>
        <Route path="/" element={<ValeraList />} />
        <Route path="/valera/:id" element={<ValeraStats />} />
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} /> {/* ← и эту */}
      </Routes>
    </BrowserRouter>
  );
}

export default App;