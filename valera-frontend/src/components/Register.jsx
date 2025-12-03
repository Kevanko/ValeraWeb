import React, { useState } from 'react';
import {
  Container,
  TextField,
  Button,
  Typography,
  Box,
  Alert,
  Paper
} from '@mui/material';
import { register } from '../services/api';

export default function Register() {
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [success, setSuccess] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setSuccess(false);

    if (!username || !email || !password) {
      setError('Все поля обязательны');
      return;
    }

    try {
      await register({ username, email, password });
      setSuccess(true);
      setError('');
      // Можно автоматически перейти через 2 сек
      setTimeout(() => {
        window.location.href = '/login';
      }, 2000);
    } catch (err) {
      console.error('Ошибка регистрации:', err);
      const msg = err.response?.data?.message || 'Неизвестная ошибка регистрации';
      setError(msg);
    }
  };

  return (
    <Container maxWidth="sm" sx={{ mt: 8 }}>
      <Paper elevation={3} sx={{ p: 4 }}>
        <Typography variant="h4" align="center" gutterBottom>
          Регистрация
        </Typography>

        {error && <Alert severity="error" sx={{ mb: 2 }}>{error}</Alert>}
        {success && <Alert severity="success" sx={{ mb: 2 }}>✅ Успешно зарегистрировано! Переход на вход...</Alert>}

        <form onSubmit={handleSubmit}>
          <TextField
            fullWidth
            label="Имя пользователя"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            margin="normal"
            required
          />
          <TextField
            fullWidth
            label="Email"
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            margin="normal"
            required
          />
          <TextField
            fullWidth
            label="Пароль"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            margin="normal"
            required
          />
          <Button
            type="submit"
            variant="contained"
            color="primary"
            fullWidth
            sx={{ mt: 3, py: 1.5 }}
          >
            Зарегистрироваться
          </Button>
        </form>

        <Box sx={{ textAlign: 'center', mt: 2 }}>
          <Button onClick={() => window.location.href = '/login'}>
            Уже есть аккаунт? Войти
          </Button>
        </Box>
      </Paper>
    </Container>
  );
}