import React from 'react';
import { AppBar, Toolbar, Typography, Button } from '@mui/material';

export default function Header() {
  const user = JSON.parse(localStorage.getItem('user'));
  const token = localStorage.getItem('token');

  const handleLogout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    window.location.href = '/login';
  };

  if (!token) return null; // Не показываем, если не авторизован

  return (
    <AppBar position="static" color="primary">
      <Toolbar>
        <Typography variant="h6" sx={{ flexGrow: 1 }}>
          Валера-менеджер
        </Typography>
        {user && (
          <div>
            <Typography variant="body1" sx={{ display: 'inline', mr: 2, color: 'white' }}>
              {user.email} ({user.role})
            </Typography>
            <Button color="inherit" onClick={handleLogout}>
              Выйти
            </Button>
          </div>
        )}
      </Toolbar>
    </AppBar>
  );
}